using System;
using System.Collections.Generic;
using Habitat.Application.Extensions;
using Habitat.Application.Interfaces;

namespace Habitat.Application.Notes.Commands.Models
{
    public class UpdateNotesModel : IModelValidator
    {
        public List<UpdateNoteModel> Notes { get; set; } = new List<UpdateNoteModel>();
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