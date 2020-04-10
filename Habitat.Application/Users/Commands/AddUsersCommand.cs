using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Application.Users.Commands.Models;
using Habitat.Domain.Users;
using Microsoft.Extensions.Logging;

namespace Habitat.Application.Users.Commands
{
    public class AddUsersCommand : IAddUsersCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AddUsersCommand> _logger;

        public AddUsersCommand(IUserRepository userRepository, ILogger<AddUsersCommand> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        
        public async Task<AddUsersResponseModel> ExecuteAsync(AddUsersRequestModel request, CancellationToken cancellationToken = default)
        {
            var usernames = request.Users.Select(user => user.UserName);
            
            _logger.LogInformation("Checking if users already exist");
            var anyUsersExist = _userRepository.GetAll().Any(user => usernames.Contains(user.UserName));

            if (anyUsersExist)
            {
                _logger.LogInformation("Users already exist");
                return new AddUsersResponseModel
                {
                    Success = false
                };
            }

            var newUsers = request.Users.Select(userRequest => new User
            {
                UserName = userRequest.UserName
            });

            _logger.LogInformation("Adding users");
            await _userRepository.AddRangeAsync(newUsers, cancellationToken);
            
            _logger.LogInformation("Saving changes to data store");
            await _userRepository.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Getting users from database");
            var databaseUsers = _userRepository.GetAll().Where(user => usernames.Contains(user.UserName)).ToList();
            
            return new AddUsersResponseModel
            {
                Success = true,
                Users = databaseUsers.Select(user => new UserResponseModel
                {
                    Id = user.Id,
                    UserName = user.UserName
                }).ToList()
            };
        }
    }
}