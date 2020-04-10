using System;

namespace Habitat.Application.Notes.Queries.Models
{
    public class GetNoteResponseModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}