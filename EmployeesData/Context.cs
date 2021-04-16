using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.EmployeesData
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>opt): base(opt)
        {

        }

        public DbSet<Employee> employees { get; set; }

     }
}
