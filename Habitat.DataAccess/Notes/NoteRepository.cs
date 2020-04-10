using Habitat.Application.Interfaces;
using Habitat.DataAccess.Interfaces;
using Habitat.DataAccess.Repositories;
using Habitat.Domain.Notes;
using Microsoft.Extensions.Logging;

namespace Habitat.DataAccess.Notes
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(IHabitatContext database, ILogger<Repository<Note>> logger) : base(database, logger)
        {
        }
    }
}