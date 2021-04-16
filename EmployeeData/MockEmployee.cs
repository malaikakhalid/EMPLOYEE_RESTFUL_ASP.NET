using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.IEmployeeData
{
    public class MockEmployee : IEmployeeData
    {
        public IEnumerable<Employee> GetAppCommand()
        {
            var employees = new List<Employee>
            {
                new Employee
            {
                ID = 0,
                Name = "Malaika Khalid",
                Age = 20
            },
                new Employee
            {
                ID = 1,
                Name = "Malaika Khalid",
                Age = 20
            },
                new Employee
            {
                ID = 2,
                Name = "Malaika Khalid",
                Age = 20
            }
            };
                return employees;

        
        }

        public Employee GetCommandById(int id)
        {
            return new Employee
            {
                ID = 0,
                Name = "Malaika Khalid",
                Age = 20
            };

        }
    }
}
