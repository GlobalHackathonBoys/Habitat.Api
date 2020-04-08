namespace Habitat.Application.Interfaces
{
    public interface IVoidCommand<in TRequest>
    {
        void Execute(TRequest request);
    }
}