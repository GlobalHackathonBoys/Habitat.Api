using System;
using System.Collections.Generic;
using System.Linq;
using Habitat.Application.Interfaces;
using Habitat.Application.Notes.Commands.Models;
using Habitat.Application.Notes.Queries.Models;
using Habitat.Domain.Models;
using Habitat.Domain.Notes;
using Microsoft.Extensions.Logging;

namespace Habitat.Application.Notes.Queries
{
    public class GetTodaysNotesQuery : IGetTodaysNotesQuery
    {
        private readonly INoteRepository _noteRepository;
        private readonly ILogger<GetTodaysNotesQuery> _logger;

        public GetTodaysNotesQuery(
            INoteRepository noteRepository,
            ILogger<GetTodaysNotesQuery> logger)
        {
            _noteRepository = noteRepository;
            _logger = logger;
        }

        public GetNotesResponseModel Execute(GetTodaysNotesModel model)
        {
            _logger.LogInformation("Getting today's notes");
            
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(model.TimeZone);
            var offset = timeZone.BaseUtcOffset;
            var nowInTimeZone = (DateTime.UtcNow + offset).Date;
            
            var notes = _noteRepository
                .GetAll()
                .Where(note => note.UserId == model.UserId)
                .Where(note => (note.EventDateTime + offset).Date == nowInTimeZone)
                .Select(note => new GetNoteResponseModel
                {
                    Id = note.Id,
                    Text = note.NoteText,
                    DateTime = note.EventDateTime
                })
                .OrderByDescending(note => note.DateTime)
                .ToList();
            
            _logger.LogInformation("Retrieved today's notes");
            
            return new GetNotesResponseModel
            {
                UserId = model.UserId,
                Notes = notes
            };
        }
    }
}