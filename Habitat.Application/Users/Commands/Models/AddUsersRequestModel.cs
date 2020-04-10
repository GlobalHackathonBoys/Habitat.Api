using System.Collections.Generic;
using Habitat.Application.Extensions;
using Habitat.Application.Interfaces;

namespace Habitat.Application.Users.Commands.Models
{
    public class AddUsersRequestModel : IModelValidator
    {
        public List<AddUserRequestModel> Users { get; set; } = new List<AddUserRequestModel>();
        public List<string> Validate()
        {
            return Users.ToModelValidationList();
        }
    }
}