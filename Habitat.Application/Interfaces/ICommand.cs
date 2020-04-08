namespace Habitat.Application.Interfaces
{
    public interface ICommand<in TRequest, out TResponse>
    {
        TResponse Execute(TRequest request);
    }

    public interface ICommand<out TResponse>
    {
        TResponse Execute();
    }
}