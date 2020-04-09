using System.Threading;
using System.Threading.Tasks;

namespace Habitat.Application.Interfaces
{
    public interface IAsyncCommand<TResponse>
    {
        Task<TResponse> Execute(CancellationToken cancellationToken = default);
    }

    public interface IAsyncCommand<in TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);
    }
}