using Habitat.Application.Users;
using Habitat.DataAccess.Interfaces;
using Habitat.DataAccess.Repositories;
using Habitat.Domain.Users;
using Microsoft.Extensions.Logging;

namespace Habitat.DataAccess.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        protected UserRepository(IHabitatContext database, ILogger<Repository<User>> logger) : base(database, logger)
        {
        }
    }
}