using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Application.Interfaces;
using Habitat.DataAccess.Interfaces;
using Habitat.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Habitat.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IDataEntity
    {
        private readonly IHabitatContext _database;
        private readonly ILogger<Repository<T>> _logger;

        protected Repository(IHabitatContext database, ILogger<Repository<T>> logger)
        {
            _database = database;
            _logger = logger;
        }
        
        public IQueryable<T> GetAll()
        {
            _logger.LogTrace($"Getting all {typeof(T).Name}");
            return _database.DataEntitySet<T>();
        }

        public IQueryable<T> Get(IEnumerable<Guid> ids)
        {
            _logger.LogTrace($"Getting {typeof(T).Name} entities");
            return _database.DataEntitySet<T>().Where(entity => ids.Contains(entity.Id));
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"Adding {typeof(T).Name} entities");
            await _database.DataEntitySet<T>().AddRangeAsync(entities, cancellationToken);
        }

        public void Remove(IEnumerable<T> entities)
        {
            _logger.LogTrace($"Removing {typeof(T).Name} entities");
            _database.DataEntitySet<T>().RemoveRange(entities);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"Saving {typeof(T).Name} entities");
            
            return await _database.SaveChangesAsync(cancellationToken);
        }

        public async Task<ITransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            var transaction = await _database.BeginTransactionAsync(cancellationToken);
            return new TransactionWrapper(transaction);
        }
    }
}