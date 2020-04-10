using System.Collections.Generic;

namespace Habitat.Application.Users.Commands.Models
{
    public class AddUsersResponseModel
    {
        public bool Success { get; set; }
        public List<UserResponseModel> Users { get; set; } = new List<UserResponseModel>();
    }
}