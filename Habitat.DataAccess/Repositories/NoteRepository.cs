using Habitat.Application.Interfaces;
using Habitat.DataAccess.Interfaces;
using Habitat.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Habitat.DataAccess.Repositories
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(IHabitatContext database, ILogger<Repository<Note>> logger) : base(database, logger)
        {
        }
    }
}