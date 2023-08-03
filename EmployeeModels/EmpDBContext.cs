using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModels
{
    public class EmpDBContext:DbContext
    {
        public EmpDBContext(DbContextOptions<EmpDBContext> options) : base(options)
        {

        }
        public DbSet<Departments> Departments { get; set; }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<SalaryDetails> SalaryDetails { get; set; }

        public DbSet<AccountDetails> AccountDetails { get; set; }
    }
}
