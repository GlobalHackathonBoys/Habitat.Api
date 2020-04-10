using System.Collections.Generic;
using Habitat.Application.Interfaces;
using Habitat.Domain.Models;
using Habitat.Domain.Notes;

namespace Habitat.Application.Notes.Queries
{
    public interface IGetAllNotesQuery : IQuery<IEnumerable<Note>>
    {
    }
}