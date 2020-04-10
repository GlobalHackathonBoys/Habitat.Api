using Habitat.Application.Interfaces;
using Habitat.Application.Todos.Commands.Models;

namespace Habitat.Application.Todos.Commands
{
    public interface IAddTodosCommand : IAsyncCommand<AddTodosRequestModel, AddTodosResponseModel>
    {
    }
}