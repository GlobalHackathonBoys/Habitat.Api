using System.Collections.Generic;
using System.Linq;
using Habitat.Application.Interfaces;
using Habitat.Domain.Models;
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
        
        public IEnumerable<Note> Execute()
        {
            _logger.LogInformation("Getting all notes");
            var notes = _noteRepository.GetAll().ToList();
            _logger.LogInformation("Retrieved all notes");
            return notes;
        }
    }
}