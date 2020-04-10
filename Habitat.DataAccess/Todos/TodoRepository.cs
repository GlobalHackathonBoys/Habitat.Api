using Habitat.Application.Todos;
using Habitat.DataAccess.Interfaces;
using Habitat.DataAccess.Repositories;
using Habitat.Domain.Todos;
using Microsoft.Extensions.Logging;

namespace Habitat.DataAccess.Todos
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        public TodoRepository(IHabitatContext database, ILogger<Repository<Todo>> logger) : base(database, logger)
        {
        }
    }
}