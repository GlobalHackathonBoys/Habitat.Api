using System.Threading;
using System.Threading.Tasks;

namespace Habitat.Application.Interfaces
{
    public interface IAsyncQuery<TResponse>
    {
        Task<TResponse> Execute(CancellationToken cancellationToken = default);
    }

    public interface IAsyncQuery<in TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);
    }
}