using System;
using System.Collections.Generic;

namespace Habitat.Application.Notes.Commands.Models
{
    public class AddNotesResponse
    {
        public bool Success { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> NoteIds { get; set; } = new List<Guid>();
    }
}