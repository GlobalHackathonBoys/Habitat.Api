using System.Collections.Generic;
using System.Linq;
using Habitat.Application.Extensions;
using Habitat.Application.Interfaces;

namespace Habitat.Application.Notes.Commands.Models
{
    public class UpdateNotesModel : IModelValidator
    {
        public List<UpdateNoteModel> Notes { get; set; } = new List<UpdateNoteModel>();

        public List<string> Validate()
        {
            return Notes.ToModelValidationList();
        }
    }
}