using System.Collections.Generic;
using Aylien.NewsApi.Model;
using NewsAPI.Models;

namespace Habitat.News
{
    public interface IHabitatNews
    {
        List<ArticleResponse> GetNews(string searchPhrase);

        List<ArticleResponse> GetPositiveNewsByPhrase(string searchPhrase);
    }
}