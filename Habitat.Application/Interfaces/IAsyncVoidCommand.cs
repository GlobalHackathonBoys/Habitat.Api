using System.Threading.Tasks;

namespace Habitat.Application.Interfaces
{
    public interface IAsyncVoidCommand<in TRequest>
    {
        Task Execute(TRequest request);
    }
}