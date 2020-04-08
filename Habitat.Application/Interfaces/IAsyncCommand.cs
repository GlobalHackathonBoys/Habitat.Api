using System.Threading.Tasks;

namespace Habitat.Application.Interfaces
{
    public interface IAsyncCommand<TResponse>
    {
        Task<TResponse> Execute();
    }

    public interface IAsyncCommand<in TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}