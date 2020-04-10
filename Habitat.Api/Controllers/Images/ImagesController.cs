using System.Collections.Generic;
using Aylien.NewsApi.Model;
using Habitat.Images;
using Habitat.News;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;

namespace Habitat.Api.Controllers.News
{
    [Produces("application/json")]
    [ApiController]
    [Route("images")]
    public class ImagesController : ControllerBase
    {

        private readonly IImageSearch _imageSearch;

        public ImagesController(IImageSearch imageSearch)
        {
            _imageSearch = imageSearch;
        }

        [HttpGet]
        public List<string> GetImages([FromQuery] string searchPhrase)
        {
            return _imageSearch.GetImageUrls(searchPhrase);
        }
        
    }
}