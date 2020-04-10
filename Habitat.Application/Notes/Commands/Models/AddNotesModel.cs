using System;
using System.Collections.Generic;
using Habitat.Application.Extensions;
using Habitat.Application.Interfaces;

namespace Habitat.Application.Notes.Commands.Models
{
    public class AddNotesModel : IModelValidator
    {
        public List<AddNoteModel> Notes { get; set; } = new List<AddNoteModel>();
        public Guid UserId { get; set; }
        public List<string> Validate()
        {
            var valid = Notes.ToModelValidationList();

            if (UserId == Guid.Empty)
            {
                valid.Add($"{nameof(UserId)} is Empty");
            }

            return valid;
        }
    }
}