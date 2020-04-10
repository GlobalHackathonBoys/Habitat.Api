using System.Collections.Generic;
using Aylien.NewsApi.Model;
using Habitat.News;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;

namespace Habitat.Api.Controllers.News
{
    [Produces("application/json")]
    [ApiController]
    [Route("news")]
    public class NewsController : ControllerBase
    {
        private readonly IHabitatNews _habitatNews;

        public NewsController(IHabitatNews habitatNews)
        {
            _habitatNews = habitatNews;
        }

        [HttpGet]
        public List<ArticleResponse> GetNews([FromQuery] string searchPhrase)
        {
            return _habitatNews.GetNews(searchPhrase);
        }
        
    }
}