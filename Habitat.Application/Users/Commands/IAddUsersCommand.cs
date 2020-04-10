using Habitat.Application.Interfaces;
using Habitat.Application.Users.Commands.Models;

namespace Habitat.Application.Users.Commands
{
    public interface IAddUsersCommand : IAsyncCommand<AddUsersRequestModel, AddUsersResponseModel>
    {
    }
}