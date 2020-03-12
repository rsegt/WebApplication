using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DataAcces.Contracts
{
    public interface IStudentDao<T> : ICreate<T>, IDeleteById<T>, IGetAll<T>, IUpdate<T>
    {
    }
}
