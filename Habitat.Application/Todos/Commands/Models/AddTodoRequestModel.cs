using System;
using System.Collections.Generic;
using Habitat.Application.Interfaces;

namespace Habitat.Application.Todos.Commands.Models
{
    public class AddTodoRequestModel : IModelValidator
    {
        public AddTodoRequestModel()
        {
            DateTime = DateTimeOffset.UtcNow;
        }
        
        public bool Done { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public string Text { get; set; }
        public List<string> Validate()
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(Text) || string.IsNullOrWhiteSpace(Text))
            {
                errors.Add($"{nameof(Text)} is null empty or whitespace");
            }

            return errors;
        }
    }
}