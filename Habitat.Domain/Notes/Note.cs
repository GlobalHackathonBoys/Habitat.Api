using System;
using Habitat.Domain.Models;
using Habitat.Domain.Users;

namespace Habitat.Domain.Notes
{
    public class Note : CalendarItem
    {
        public string NoteText { get; set; }
        
        // relationships
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}