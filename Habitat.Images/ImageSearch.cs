using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Habitat.Images.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace Habitat.Images
{
    public class ImageSearch : IImageSearch
    {
        private readonly ILogger<IImageSearch> _logger;
        private const string pixaBayUrl = "https://pixabay.com/api/";

        private readonly RestClient _restClient;

        private readonly string _pixaBayApiKey;

        public ImageSearch(IConfiguration configuration, ILogger<IImageSearch> logger)
        {
            _logger = logger;
            _pixaBayApiKey = configuration["PixaBayApiKey"];

            _restClient = new RestClient(pixaBayUrl);
        }

        List<string> IImageSearch.GetImageUrls(string searchPhrase)
        {
            var request = new RestRequest("");
            
            _logger.LogInformation($"Performing Image Search for : {searchPhrase}");
            request.AddOrUpdateParameters(new List<Parameter>()
            {
                new Parameter("key", _pixaBayApiKey, ParameterType.QueryString),
                new Parameter("q", HttpUtility.UrlEncode(searchPhrase), ParameterType.QueryString),
                new Parameter("lang", "en", ParameterType.QueryString),
                new Parameter("image_type", "photo", ParameterType.QueryString)
            });
            var response = _restClient.Get(request);

            if (response.IsSuccessful)
            {
             
                var imageResults = JsonConvert.DeserializeObject<ImageResults>(response.Content);

                _logger.LogInformation($"Found {imageResults.Total} images matching search criteria.");
                return imageResults.Hits.Select(x => x.LargeImageUrl).ToList();
            }
            
            _logger.LogError($"Failed to fetch images : {response.ErrorMessage}");

            return null;

        }
    }
}