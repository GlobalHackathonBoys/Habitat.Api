using System;
using Habitat.Domain.Interfaces;

namespace Habitat.Domain.Models
{
    public class CalendarItem : DataEntity, ICalendarItem
    {
        public DateTime EventDateTime { get; set; } = DateTime.UtcNow;
    }
}