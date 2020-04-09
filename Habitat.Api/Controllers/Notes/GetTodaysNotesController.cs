using System.Collections.Generic;
using Habitat.Application.Notes.Commands.Models;
using Habitat.Application.Notes.Queries;
using Habitat.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Habitat.Api.Controllers.Notes
{
    [Produces("application/json")]
    [ApiController]
    [Route("notes/today")]
    public class GetTodaysNotesController
    {
        private readonly IGetTodaysNotesQuery _query;
        private readonly ILogger<GetTodaysNotesController> _logger;

        public GetTodaysNotesController(IGetTodaysNotesQuery query, ILogger<GetTodaysNotesController> logger)
        {
            _query = query;
            _logger = logger;
        }
        
        [HttpGet]
        public IEnumerable<Note> Get([FromQuery] GetTodaysNotesModel request)
        {
            _logger.LogTrace($"{nameof(GetAllNotesController)}.{nameof(Get)} hit");
            return _query.Execute(request);
        }
    }
}