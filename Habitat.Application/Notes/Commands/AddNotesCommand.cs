using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Application.Interfaces;
using Habitat.Application.Notes.Commands.Models;
using Habitat.Domain.Models;
using Habitat.Domain.Notes;
using Microsoft.Extensions.Logging;

namespace Habitat.Application.Notes.Commands
{
    public class AddNotesCommand : IAddNotesCommand
    {
        private readonly INoteRepository _noteRepository;
        private readonly ILogger<AddNotesCommand> _logger;

        public AddNotesCommand(INoteRepository noteRepository, ILogger<AddNotesCommand> logger)
        {
            _noteRepository = noteRepository;
            _logger = logger;
        }
        
        public async Task<List<Guid>> ExecuteAsync(AddNotesModel request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Creating new notes");
            var notes = request.Notes.Select(note => new Note
            {
                NoteText = note.Text
            }).ToList();

            _logger.LogInformation("Adding new notes to data store");
            await _noteRepository.AddRangeAsync(notes, cancellationToken);
            _logger.LogInformation("Saving changes to data store");
            await _noteRepository.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Added new notes to data store");
            return notes.Select(note => note.Id).ToList();
        }
    }
}