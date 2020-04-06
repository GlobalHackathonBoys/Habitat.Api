using System;

namespace Habitat.DataAccess.Models
{
    public class Note : IDataEntity, ICalendarItem
    {
        public Guid Id { get; set; }
        public DateTime EventDateTime { get; set; }
        public string NoteText { get; set; }
    }
}