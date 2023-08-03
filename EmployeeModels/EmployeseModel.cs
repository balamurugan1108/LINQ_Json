using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModels
{
    public class Departments
    {
        [Key]
        public int? DepartmentId { get; set; }
        public string? DepName { get; set; }
    }

    public class Employees
    {
        [Key]
        public int? EmpID { get; set; }
        public string? EmpName { get; set; }
        public int? EmpAge { get; set; }
        public int? DepartmentID { get; set; }

    }

    public class SalaryDetails
    {
        [Key]
        public int? SalaryId { get; set; }
        public int? SalaryAmount { get; set; }
        public int? EmpID { get; set; }

    }

    public class AccountDetails
    {
        [Key]
        public string AccType { get; set; }
        public string AccHolderName { get; set; }
        public int SalaryId { get; set; }

    }
}
