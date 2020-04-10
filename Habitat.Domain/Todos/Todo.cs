using System;
using Habitat.Domain.Models;
using Habitat.Domain.Users;

namespace Habitat.Domain.Todos
{
    public class Todo : CalendarItem
    {
        public bool Done { get; set; }
        public string NoteText { get; set; }
        
        // relationships
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}