using System.Collections.Generic;
using System.Linq;
using Habitat.Api.Constants;
using Habitat.Application.Users.Queries;
using Habitat.Application.Users.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Habitat.Api.Controllers.Users
{
    [Produces("application/json")]
    [ApiController]
    [Route("users")]
    public class GetUsersController : ControllerBase
    {
        private readonly IGetUsersByUsernamesQuery _query;
        private readonly ILogger<GetUsersController> _logger;

        public GetUsersController(IGetUsersByUsernamesQuery query, ILogger<GetUsersController> logger)
        {
            _query = query;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] {SwaggerTags.Users})]
        public IActionResult Get([FromQuery] List<string> usernames)
        {
            _logger.LogTrace($"{nameof(GetUsersController)}.{nameof(Get)} hit");
            
            var request = new GetUsersByUsernamesRequestModel
            {
                Usernames = usernames
            };

            var errors = request.Validate();

            if (errors.Any())
            {
                return BadRequest(errors);
            }

            var response = _query.Execute(request);
            return Ok(response);
        }
    }
}