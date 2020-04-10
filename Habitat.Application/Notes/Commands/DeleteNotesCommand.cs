using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Application.Interfaces;
using Habitat.Application.Notes.Commands.Models;
using Microsoft.Extensions.Logging;

namespace Habitat.Application.Notes.Commands
{
    public class DeleteNotesCommand : IDeleteNotesCommand
    {
        private readonly INoteRepository _noteRepository;
        private readonly ILogger<DeleteNotesCommand> _logger;

        public DeleteNotesCommand(INoteRepository noteRepository, ILogger<DeleteNotesCommand> logger)
        {
            _noteRepository = noteRepository;
            _logger = logger;
        }
        
        public async Task Execute(DeleteNotesModel request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Getting notes to delete");
            var notesToDelete = _noteRepository.Get(request.NoteIds).Where(note => note.UserId == request.UserId);
            _logger.LogInformation("Deleting notes");
            _noteRepository.Remove(notesToDelete);
            _logger.LogInformation("Saving changes to data store");
            await _noteRepository.SaveChangesAsync(cancellationToken);
        }
    }
}