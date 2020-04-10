using System;
using System.Collections.Generic;

namespace Habitat.Application.Todos.Commands.Models
{
    public class AddTodosResponseModel
    {
        public List<Guid> TodoIds { get; set; }
        public Guid UserId { get; set; }
        public bool Success { get; set; }
    }
}