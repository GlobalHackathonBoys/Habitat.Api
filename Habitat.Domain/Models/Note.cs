using System;
using Habitat.Domain.Interfaces;

namespace Habitat.Domain.Models
{
    public class Note : IDataEntity, ICalendarItem
    {
        public Guid Id { get; set; }
        public DateTime EventDateTime { get; set; }
        public string NoteText { get; set; }
    }
}