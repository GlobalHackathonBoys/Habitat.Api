using System.Collections.Generic;
using Habitat.Application.Interfaces;

namespace Habitat.Application.Users.Commands.Models
{
    public class AddUserRequestModel : IModelValidator
    {
        public string UserName { get; set; }
        public List<string> Validate()
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(UserName))
            {
                errors.Add($"{nameof(UserName)} is null or empty");
            }
            
            return errors;
        }
    }
}