using System.Collections.Generic;
using Habitat.Domain.Models;
using Habitat.Domain.Notes;

namespace Habitat.Domain.Users
{
    public class User : DataEntity
    {
        public virtual ICollection<Note> Notes { get; set; }
    }
}