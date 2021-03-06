using System.Collections.Generic;
using Habitat.Application.Interfaces;
using Habitat.Application.Notes.Queries.Models;
using Habitat.Domain.Models;
using Habitat.Domain.Notes;

namespace Habitat.Application.Notes.Queries
{
    public interface IGetAllNotesQuery : IQuery<List<GetNoteResponseModel>>
    {
    }
}