using System;
using System.Collections.Generic;
using Habitat.Application.Interfaces;

namespace Habitat.Application.Notes.Commands.Models
{
    public class AddNoteModel : IModelValidator
    {
        public string Text { get; set; }
        public List<string> Validate()
        {
            var errors = new List<string>();
            
            if (Text == null)
            {
                errors.Add($"{nameof(Text)} is null");
            }

            return errors;
        }
    }
}