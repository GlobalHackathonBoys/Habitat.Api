using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Application.Interfaces;
using Habitat.Application.Notes.Commands.Models;
using Microsoft.Extensions.Logging;

namespace Habitat.Application.Notes.Commands
{
    public class UpdateNotesCommand : IUpdateNotesCommand
    {
        private readonly INoteRepository _noteRepository;
        private readonly ILogger<UpdateNotesCommand> _logger;

        public UpdateNotesCommand(INoteRepository noteRepository, ILogger<UpdateNotesCommand> logger)
        {
            _noteRepository = noteRepository;
            _logger = logger;
        }
        
        public async Task<UpdateNotesResponse> ExecuteAsync(UpdateNotesModel request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"{nameof(UpdateNotesCommand)}.{nameof(ExecuteAsync)} hit");
            await using var transaction = await _noteRepository.BeginTransactionAsync(cancellationToken);

            try
            {
                _logger.LogInformation("Getting existing notes");
                var existingNotes = _noteRepository.Get(request.Notes.Select(note => note.Id));
                
                _logger.LogInformation("Updating notes");
                foreach (var note in request.Notes)
                {
                    var noteToUpdate = existingNotes.FirstOrDefault(n => n.Id == note.Id);

                    if (noteToUpdate == null)
                    {
                        _logger.LogWarning($"Note with id: {note.Id} does not exist. rolling back update");
                        await transaction.RollbackAsync(cancellationToken);
                        _logger.LogInformation("update rolled back");
                        return new UpdateNotesResponse
                        {
                            Success = false,
                            Notes = request.Notes
                        };
                    }

                    noteToUpdate.NoteText = note.Text;
                }

                await _noteRepository.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(cancellationToken);
                _logger.LogError(e.Message);
                
                return new UpdateNotesResponse
                {
                    Success = false,
                    Notes = request.Notes
                };
            }
            
            _logger.LogInformation("Finished updating notes");
            return new UpdateNotesResponse
            {
                Success = true,
                Notes = request.Notes
            };
        }
    }
}