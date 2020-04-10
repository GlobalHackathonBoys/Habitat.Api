using System.Linq;
using Habitat.Application.Users.Commands.Models;
using Habitat.Application.Users.Queries.Models;
using Microsoft.Extensions.Logging;

namespace Habitat.Application.Users.Queries
{
    public class GetUsersByUsernamesQuery : IGetUsersByUsernamesQuery
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<GetUsersByUsernamesQuery> _logger;

        public GetUsersByUsernamesQuery(IUserRepository userRepository, ILogger<GetUsersByUsernamesQuery> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }


        public GetUsersByUsernamesResponseModel Execute(GetUsersByUsernamesRequestModel request)
        {
            _logger.LogInformation("Getting users from database");
            var usernames = request.Usernames;
            var databaseUsers = _userRepository.GetAll().Where(user => usernames.Contains(user.UserName)).ToList();
            
            return new GetUsersByUsernamesResponseModel
            {
                Users = databaseUsers.Select(user => new UserResponseModel
                {
                    Id = user.Id,
                    UserName = user.UserName
                }).ToList()
            };
        }
    }
}