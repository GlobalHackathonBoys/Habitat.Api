using System;
using System.Threading;
using System.Threading.Tasks;

namespace Habitat.Application.Interfaces
{
    public interface ITransaction : IAsyncDisposable, IDisposable
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}