using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Api.Constants;
using Habitat.Application.Todos.Commands;
using Habitat.Application.Todos.Commands.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Habitat.Api.Controllers.Todos
{
    [Produces("application/json")]
    [ApiController]
    [Route("todos")]
    public class AddTodoController : ControllerBase
    {
        private readonly IAddTodosCommand _command;
        private readonly ILogger<AddTodoController> _logger;

        public AddTodoController(IAddTodosCommand command, ILogger<AddTodoController> logger)
        {
            _command = command;
            _logger = logger;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] {SwaggerTags.Todos})]
        public async Task<IActionResult> Post([FromBody] AddTodosRequestModel request, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"{nameof(AddTodoController)}.{nameof(Post)} hit");
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