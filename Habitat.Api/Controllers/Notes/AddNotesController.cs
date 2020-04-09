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
    public class AddNotesController : ControllerBase
    {
        private readonly IAddNotesCommand _command;
        private readonly ILogger<AddNotesController> _logger;

        public AddNotesController(IAddNotesCommand command, ILogger<AddNotesController> logger)
        {
            _command = command;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddNotesModel request, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"{nameof(AddNotesController)}.{nameof(Post)} hit");
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