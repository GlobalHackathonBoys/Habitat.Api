using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Domain.Interfaces;

namespace Habitat.Application.Interfaces
{
    public interface IRepository<T> where T : class, IDataEntity
    {
        IQueryable<T> GetAll();

        IQueryable<T> Get(IEnumerable<Guid> ids);

        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        void Remove(IEnumerable<T> entities);
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<ITransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}