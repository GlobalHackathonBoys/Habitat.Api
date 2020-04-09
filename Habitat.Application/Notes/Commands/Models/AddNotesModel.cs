using System.Collections.Generic;

namespace Habitat.Application.Notes.Commands.Models
{
    public class AddNotesModel
    {
        public List<AddNoteModel> Notes { get; set; } = new List<AddNoteModel>();
    }
}