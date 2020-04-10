using System;
using System.Collections.Generic;

namespace Habitat.Application.Todos.Commands.Models
{
    public class AddTodosRequestModel
    {
        public Guid UserId { get; set; }
        public List<AddTodoRequestModel> Todos { get; set; } = new List<AddTodoRequestModel>();
    }
}