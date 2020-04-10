using System.Collections.Generic;

namespace Habitat.Application.Users.Commands.Models
{
    public class UsersResponseModel
    {
        public List<UserResponseModel> Users { get; set; } = new List<UserResponseModel>();
    }
}