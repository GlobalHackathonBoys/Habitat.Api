using System.Threading.Tasks;

namespace Habitat.Application.Interfaces
{
    public interface IAsyncQuery<TResponse>
    {
        Task<TResponse> Execute();
    }

    public interface IAsyncQuery<in TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}