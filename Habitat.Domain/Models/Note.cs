using System;
using Habitat.Domain.Interfaces;

namespace Habitat.Domain.Models
{
    public class Note : CalendarItem
    {
        public string NoteText { get; set; }
    }
}