using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EmployeesData
{
   public interface IEmployeeData
    {
        bool SaveChanges();
        IEnumerable<Employee> GetAllCommand();
        Employee GetCommandById(int id);


        void CreateCommand(Employee cmd);
        void UpdateCommand(Employee cmd);
        void DeleteCommand(Employee cmd);
    }
}
