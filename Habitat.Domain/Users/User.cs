using System.Collections.Generic;
using Habitat.Domain.Models;
using Habitat.Domain.Notes;
using Habitat.Domain.Todos;

namespace Habitat.Domain.Users
{
    public class User : DataEntity
    {
        public string UserName { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Todo> Todos { get; set; }
    }
}