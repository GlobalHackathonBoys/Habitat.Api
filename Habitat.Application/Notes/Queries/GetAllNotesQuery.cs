using System.Collections.Generic;
using Habitat.Application.Interfaces;
using Habitat.Domain.Models;

namespace Habitat.Application.Notes.Queries
{
    public class GetAllNotesQuery : IQuery<IEnumerable<Note>>
    {
        public IEnumerable<Note> Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}