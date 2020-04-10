using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Application.Interfaces;
using Habitat.Application.Notes.Commands.Models;
using Habitat.Application.Users;
using Habitat.Domain.Models;
using Habitat.Domain.Notes;
using Microsoft.Extensions.Logging;

namespace Habitat.Application.Notes.Commands
{
    public class AddNotesCommand : IAddNotesCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly INoteRepository _noteRepository;
        private readonly ILogger<AddNotesCommand> _logger;

        public AddNotesCommand(
            IUserRepository userRepository,
            INoteRepository noteRepository, 
            ILogger<AddNotesCommand> logger)
        {
            _userRepository = userRepository;
            _noteRepository = noteRepository;
            _logger = logger;
        }
        
        public async Task<AddNotesResponse> ExecuteAsync(AddNotesModel request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Getting User: {request.UserId}");
            var user = _userRepository.Get(new[] {request.UserId}).FirstOrDefault();

            if (user == null)
            {
                _logger.LogWarning($"User: {request.UserId} does not exist");
                return new AddNotesResponse
                {
                    UserId = request.UserId,
                    Success = false
                };
            }
            
            _logger.LogInformation("Creating new notes");
            var notes = request.Notes.Select(note => new Note
            {
                NoteText = note.Text,
            }).ToList();

            _logger.LogInformation($"Adding notes to user: {user.Id}");
            foreach (var note in notes)
            {
                user.Notes.Add(note);
            }

            _logger.LogInformation("Saving changes to data store");
            await _userRepository.SaveChangesAsync(cancellationToken);
            
            return new AddNotesResponse
            {
                NoteIds = notes.Select(note => note.Id).ToList(),
                UserId = user.Id,
                Success = true
            };
        }
    }
}