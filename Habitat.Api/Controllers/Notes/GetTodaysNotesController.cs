using System.Collections.Generic;
using Habitat.Application.Notes.Commands.Models;
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
    [Route("notes/today")]
    public class GetTodaysNotesController : ControllerBase
    {
        private readonly IGetTodaysNotesQuery _query;
        private readonly ILogger<GetTodaysNotesController> _logger;

        public GetTodaysNotesController(IGetTodaysNotesQuery query, ILogger<GetTodaysNotesController> logger)
        {
            _query = query;
            _logger = logger;
        }
        
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Notes" })]
        public ActionResult Get([FromQuery] GetTodaysNotesModel request)
        {
            _logger.LogTrace($"{nameof(GetAllNotesController)}.{nameof(Get)} hit");
            return Ok(_query.Execute(request));
        }
    }
}