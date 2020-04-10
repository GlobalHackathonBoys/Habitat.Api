using System.Collections.Generic;
using System.Linq;
using Habitat.Application.Interfaces;
using Habitat.Application.Notes.Queries.Models;
using Habitat.Domain.Models;
using Habitat.Domain.Notes;
using Microsoft.Extensions.Logging;

namespace Habitat.Application.Notes.Queries
{
    public class GetAllNotesQuery : IGetAllNotesQuery
    {
        private readonly INoteRepository _noteRepository;
        private readonly ILogger<GetAllNotesQuery> _logger;

        public GetAllNotesQuery(INoteRepository noteRepository, ILogger<GetAllNotesQuery> logger)
        {
            _noteRepository = noteRepository;
            _logger = logger;
        }
        
        public List<GetNoteResponseModel> Execute()
        {
            _logger.LogInformation("Getting all notes");

            var notes = _noteRepository.GetAll().Select(note => new GetNoteResponseModel
                {
                    Id = note.Id,
                    Text = note.NoteText,
                    DateTime = note.EventDateTime
                })
                .OrderByDescending(note => note.DateTime)
                .ToList();
            
            _logger.LogInformation("Retrieved all notes");
            return notes;
        }
    }
}