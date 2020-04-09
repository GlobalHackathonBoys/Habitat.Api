using System;
using System.Collections.Generic;
using Habitat.Application.Interfaces;

namespace Habitat.Application.Notes.Commands.Models
{
    public class UpdateNoteModel : IModelValidator
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public List<string> Validate()
        {
            var errors = new List<string>();

            if (Id == Guid.Empty)
            {
                errors.Add($"{nameof(Id)} is empty");
            }

            if (Text == null)
            {
                errors.Add($"{nameof(Text)} is null");
            }

            return errors;
        }
    }
}