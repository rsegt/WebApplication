namespace WebApplication1.DataAcces.Contracts
{
    public interface IDeleteById<T>
    {
        bool DeleteById(int id);
    }
}
