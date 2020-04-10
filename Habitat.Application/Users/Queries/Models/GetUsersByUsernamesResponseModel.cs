using System.Collections.Generic;
using Habitat.Application.Users.Commands.Models;

namespace Habitat.Application.Users.Queries.Models
{
    public class GetUsersByUsernamesResponseModel
    {
        public List<UserResponseModel> Users { get; set; } = new List<UserResponseModel>();
    }
}