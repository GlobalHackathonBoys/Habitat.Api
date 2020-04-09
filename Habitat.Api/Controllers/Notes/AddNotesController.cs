using System;
using System.Collections.Generic;
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
    public class AddNotesController
    {
        private readonly IAddNotesCommand _command;
        private readonly ILogger<AddNotesController> _logger;

        public AddNotesController(IAddNotesCommand command, ILogger<AddNotesController> logger)
        {
            _command = command;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IEnumerable<Guid>> Post([FromBody] AddNotesModel request, CancellationToken cancellationToken = default)
        {
            return await _command.ExecuteAsync(request, cancellationToken);
        }
    }
}