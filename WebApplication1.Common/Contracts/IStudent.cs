using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Common.Contracts
{
    public interface IStudent
    {
        int Id { get; set; }
        string Name { get; set; }
        string Lastname { get; set; }
        DateTime BirthDate { get; set; }
    }
}
