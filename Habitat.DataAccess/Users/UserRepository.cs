using System;
using System.Collections.Generic;
using System.Linq;
using Habitat.Application.Users;
using Habitat.DataAccess.Interfaces;
using Habitat.DataAccess.Repositories;
using Habitat.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Habitat.DataAccess.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IHabitatContext database, ILogger<Repository<User>> logger) : base(database, logger)
        {
        }

        public override IQueryable<User> Get(IEnumerable<Guid> ids)
        {
            return base.Get(ids).Include(i => i.Notes).Include(i => i.Todos);
        }
    }
}