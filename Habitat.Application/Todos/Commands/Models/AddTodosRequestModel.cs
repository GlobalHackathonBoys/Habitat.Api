using System;
using System.Collections.Generic;
using Habitat.Application.Extensions;
using Habitat.Application.Interfaces;
using Habitat.Domain.Todos;

namespace Habitat.Application.Todos.Commands.Models
{
    public class AddTodosRequestModel : IModelValidator
    {
        public Guid UserId { get; set; }
        public List<AddTodoRequestModel> Todos { get; set; } = new List<AddTodoRequestModel>();
        public List<string> Validate()
        {
            var valid = Todos.ToModelValidationList();

            if (UserId == Guid.Empty)
            {
                valid.Add($"{nameof(UserId)} is Empty");
            }

            return valid;
        }
    }
}