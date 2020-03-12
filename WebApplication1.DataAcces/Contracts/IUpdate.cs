namespace WebApplication1.DataAcces.Contracts
{
    public interface IUpdate<T>
    {
        T Update(T model);
    }
}
