namespace Habitat.Application.Interfaces
{
    public interface IQuery<in TRequest, out TResponse>
    {
        TResponse Execute(TRequest request);
    }

    public interface IQuery<out TResponse>
    {
        TResponse Execute();
    }
}