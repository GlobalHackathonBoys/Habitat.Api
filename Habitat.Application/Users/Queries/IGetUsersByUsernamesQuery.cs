using Habitat.Application.Interfaces;
using Habitat.Application.Users.Queries.Models;

namespace Habitat.Application.Users.Queries
{
    public interface IGetUsersByUsernamesQuery : IQuery<GetUsersByUsernamesRequestModel, GetUsersByUsernamesResponseModel>
    {
    }
}