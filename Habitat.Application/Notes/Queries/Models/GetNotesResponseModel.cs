using System;
using System.Collections.Generic;

namespace Habitat.Application.Notes.Queries.Models
{
    public class GetNotesResponseModel
    {
        public Guid UserId { get; set; }
        public List<GetNoteResponseModel> Notes { get; set; } = new List<GetNoteResponseModel>();
    }
}