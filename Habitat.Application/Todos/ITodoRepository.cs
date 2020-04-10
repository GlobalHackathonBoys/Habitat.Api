using Habitat.Application.Interfaces;
using Habitat.Domain.Todos;

namespace Habitat.Application.Todos
{
    public interface ITodoRepository : IRepository<Todo>
    {
    }
}