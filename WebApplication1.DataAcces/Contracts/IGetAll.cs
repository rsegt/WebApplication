using System.Collections.Generic;

namespace WebApplication1.DataAcces.Contracts
{
    public interface IGetAll<T>
    {
        List<T> GetAll();
    }
}
