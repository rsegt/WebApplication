namespace WebApplication1.DataAcces.Contracts
{
    public interface ICreate<T>
    {
        T Create(T model);
    }
}
