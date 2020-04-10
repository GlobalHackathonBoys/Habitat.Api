using System.Collections.Generic;
using Aylien.NewsApi.Model;
using Habitat.News;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;

namespace Habitat.Api.Controllers.News
{
    [Produces("application/json")]
    [ApiController]
    [Route("positivenews")]
    public class PositiveNewsController : ControllerBase
    {
        private readonly IHabitatNews _habitatNews;

        public PositiveNewsController(IHabitatNews habitatNews)
        {
            _habitatNews = habitatNews;
        }

        [HttpGet]
        public List<ArticleResponse> GetPositiveNews([FromQuery] string searchPhrase)
        {
            return _habitatNews.GetPositiveNewsByPhrase(searchPhrase);
        }
    }
}