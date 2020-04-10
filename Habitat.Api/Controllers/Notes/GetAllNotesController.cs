using System.Collections.Generic;
using Habitat.Api.Constants;
using Habitat.Application.Notes.Queries;
using Habitat.Domain.Models;
using Habitat.Domain.Notes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Habitat.Api.Controllers.Notes
{
    [Produces("application/json")]
    [ApiController]
    [Route("notes")]
    public class GetAllNotesController : ControllerBase
    {
        private readonly IGetAllNotesQuery _query;
        private readonly ILogger<GetAllNotesController> _logger;

        public GetAllNotesController(IGetAllNotesQuery query, ILogger<GetAllNotesController> logger)
        {
            _query = query;
            _logger = logger;
        }
        
        [HttpGet]
        [SwaggerOperation(Tags = new[] { SwaggerTags.Notes })]
        public IActionResult Get()
        {
            _logger.LogTrace($"{nameof(GetAllNotesController)}.{nameof(Get)} hit");
            return Ok(_query.Execute());
        }
    }
}