using System.Collections.Generic;
using Habitat.Application.Interfaces;

namespace Habitat.Application.Users.Queries.Models
{
    public class GetUsersByUsernamesRequestModel : IModelValidator
    { 
        public List<string> Usernames { get; set; } = new List<string>();
        public List<string> Validate()
        {
            var errors = new List<string>();

            for (var i = 0; i < Usernames.Count; i++)
            {
                var user = Usernames[i];
                if (string.IsNullOrEmpty(user) || string.IsNullOrWhiteSpace(user))
                {
                    errors.Add($"{nameof(Usernames)}[{i}] is null or empty or whitespace");
                }
            }

            return errors;
        }
    }
}