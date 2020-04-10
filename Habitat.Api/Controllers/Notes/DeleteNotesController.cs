using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Api.Constants;
using Habitat.Application.Notes.Commands;
using Habitat.Application.Notes.Commands.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Habitat.Api.Controllers.Notes
{
    [Produces("application/json")]
    [ApiController]
    [Route("notes")]
    public class DeleteNotesController : ControllerBase
    {
        private readonly IDeleteNotesCommand _command;
        private readonly ILogger<DeleteNotesController> _logger;

        public DeleteNotesController(
            IDeleteNotesCommand command,
            ILogger<DeleteNotesController> logger)
        {
            _command = command;
            _logger = logger;
        }

        [HttpDelete]
        [SwaggerOperation(Tags = new[] { SwaggerTags.Notes })]
        public async Task<IActionResult> Delete([FromBody] DeleteNotesModel request, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"{nameof(DeleteNotesController)}.{nameof(Delete)} hit");
            var errors = request.Validate();

            if (errors.Any())
            {
                return BadRequest(errors);
            }
            
            await _command.Execute(request, cancellationToken);

            return Ok();
        }
    }
}