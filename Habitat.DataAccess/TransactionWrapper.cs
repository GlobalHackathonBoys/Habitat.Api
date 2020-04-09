using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Habitat.DataAccess
{
    public class TransactionWrapper : ITransaction
    {
        private readonly IDbContextTransaction _transaction;

        public TransactionWrapper(IDbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.CommitAsync(cancellationToken);
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.RollbackAsync(cancellationToken);
        }

        public async ValueTask DisposeAsync()
        {
            await _transaction.DisposeAsync();
        }
        
    }
}