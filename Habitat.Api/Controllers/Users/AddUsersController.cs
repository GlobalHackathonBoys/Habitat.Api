using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Api.Constants;
using Habitat.Application.Users.Commands;
using Habitat.Application.Users.Commands.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Habitat.Api.Controllers.Users
{
    [Produces("application/json")]
    [ApiController]
    [Route("users")]
    public class AddUsersController : ControllerBase
    {
        private readonly IAddUsersCommand _command;
        private readonly ILogger<AddUsersCommand> _logger;

        public AddUsersController(IAddUsersCommand command, ILogger<AddUsersCommand> logger)
        {
            _command = command;
            _logger = logger;
        }
        
        [HttpPost]
        [SwaggerOperation(Tags = new[] { SwaggerTags.Users })]
        public async Task<IActionResult> Post([FromBody] AddUsersRequestModel request, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"{nameof(AddUsersController)}.{nameof(Post)} hit");
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