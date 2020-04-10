using System;
using System.Collections.Generic;
using System.Linq;
using Aylien.NewsApi.Api;
using Aylien.NewsApi.Client;
using Aylien.NewsApi.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace Habitat.News
{
    public class HabitatNews : IHabitatNews
    {
        private readonly ILogger<IHabitatNews> _logger;
        private NewsApiClient _newsApiClient;
        private DefaultApi _aylienApi;

        public HabitatNews(IConfiguration configuration, ILogger<IHabitatNews> logger)
        {
            _logger = logger;
            var apiKey = configuration["News:ApiKey"];
            _logger.LogInformation("Creating NewsApi instance");
            _newsApiClient = new NewsApiClient(apiKey);

            var aylienAppId = configuration["Aylien:AppID"];
            var aylienApiKey = configuration["Aylien:APIKey"];

            if (Configuration.Default.ApiKey.Count != 2)
            {
                Configuration.Default.ApiKey.Add("X-AYLIEN-NewsAPI-Application-ID", aylienAppId);
                Configuration.Default.ApiKey.Add("X-AYLIEN-NewsAPI-Application-Key", aylienApiKey);
            }

            _aylienApi = new DefaultApi();
        }

        public List<ArticleResponse> GetNews(string searchPhrase)
        {
            var articlesResponse = _newsApiClient.GetEverything(new EverythingRequest
            {
                Q = string.Join(" OR ", searchPhrase.Split(" ")),
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = DateTime.Now.AddDays(-1),
                PageSize = 100,
            });

            if (articlesResponse.Status != Statuses.Ok)
            {
                _logger.LogError($"Failed to fetch News, Error {articlesResponse.Error.Message}");
                return null;
            }

            _logger.LogInformation($"Fetched {articlesResponse.TotalResults} articles with phrase {searchPhrase}");

            return articlesResponse.Articles.Select(x => new ArticleResponse() {Title = x.Title, Url = x.Url}).ToList();
        }

        public List<ArticleResponse> GetPositiveNewsByPhrase(string searchPhrase)
        {
            try
            {
                var articles = _aylienApi.ListStories(
                    title: searchPhrase, publishedAtStart: "NOW-1DAYS", publishedAtEnd: "NOW",
                    language: new List<string>() {"en"}, sentimentTitlePolarity: "positive");

                _logger.LogInformation($"Fetched {articles._Stories.Count} articles with phrase {searchPhrase}");

                return articles._Stories.Select(x => new ArticleResponse() {Title = x.Title, Url = x.Links.Canonical})
                    .ToList();
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to fetch News", e);
                throw;
            }
        }
    }
}