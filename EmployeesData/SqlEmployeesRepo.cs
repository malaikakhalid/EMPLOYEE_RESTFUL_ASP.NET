using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EmployeesData
{
    public class SqlEmployeesRepo : IEmployeeData
    {
        private readonly Context _context;

        public SqlEmployeesRepo(Context context)
        {
            _context = context; 

        }

        public void CreateCommand(Employee cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.employees.Add(cmd);
        }

        public void DeleteCommand(Employee cmd)
        {
            _context.employees.Remove(cmd);
        }

        public IEnumerable<Employee> GetAllCommand()
        {
            return _context.employees.ToList();
        }

        public Employee GetCommandById(int id)
        {
            return _context.employees.FirstOrDefault(p => p.ID == id);
        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Employee cmd)
        {
            //nothing
        }
    }
}
