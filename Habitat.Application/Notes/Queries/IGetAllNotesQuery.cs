using System.Collections.Generic;
using Habitat.Application.Interfaces;
using Habitat.Domain.Models;

namespace Habitat.Application.Notes.Queries
{
    public interface IGetAllNotesQuery : IQuery<IEnumerable<Note>>
    {
    }
}