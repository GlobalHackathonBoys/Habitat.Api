using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Application.Notes.Commands;
using Habitat.Application.Notes.Commands.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Habitat.Api.Controllers.Notes
{
    [Produces("application/json")]
    [ApiController]
    [Route("notes")]
    public class UpdateNotesController : ControllerBase
    {
        private readonly IUpdateNotesCommand _command;
        private readonly ILogger<UpdateNotesController> _logger;

        public UpdateNotesController(IUpdateNotesCommand command, ILogger<UpdateNotesController> logger)
        {
            _command = command;
            _logger = logger;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateNotesModel request, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"{nameof(UpdateNotesController)}.{nameof(Put)} hit");
            var errors = request.Validate();

            if (errors.Any())
            {
                return BadRequest(errors);
            }

            var response = await _command.ExecuteAsync(request, cancellationToken);
            return Ok(response);
        }
    }
}