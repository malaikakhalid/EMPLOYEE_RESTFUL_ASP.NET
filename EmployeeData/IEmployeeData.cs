using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.IEmployeeData
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAppCommand();
        Employee GetCommandById(int id);

    }
}
