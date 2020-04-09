using System.Collections.Generic;
using Habitat.Application.Extensions;
using Habitat.Application.Interfaces;

namespace Habitat.Application.Notes.Commands.Models
{
    public class AddNotesModel : IModelValidator
    {
        public List<AddNoteModel> Notes { get; set; } = new List<AddNoteModel>();
        public List<string> Validate()
        {
            return Notes.ToModelValidationList();
        }
    }
}