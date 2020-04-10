using System.Collections.Generic;
using Habitat.Application.Interfaces;
using Habitat.Application.Notes.Commands.Models;
using Habitat.Domain.Models;
using Habitat.Domain.Notes;

namespace Habitat.Application.Notes.Queries
{
    public interface IGetTodaysNotesQuery : IQuery<GetTodaysNotesModel, IEnumerable<Note>>
    {
        
    }
}