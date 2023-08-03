using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class EmployeeCls : IEmployeeCls
    {
        private readonly EmpDBContext _empDB;

        public EmployeeCls(EmpDBContext empDb)
        {
            _empDB = empDb;
        }
        public object getEmpDetails()
        {
            var Dep = _empDB.Departments.ToList();
            var Emp = _empDB.Employees.ToList();
            var Salary = _empDB.SalaryDetails.ToList();
            var Account = _empDB.AccountDetails.ToList();

            /*    var JoinQuery = from e in Emp
                            join d in Dep on e.DepartmentID equals d.DepartmentId
                            join s in Salary on e.EmpID equals s.EmpID
                            join a in Account on s.SalaryId equals a.SalaryId
                            select new
                            {
                                EmployeeName = e.EmpName,
                                EmployeeAge = e.EmpAge,
                                DepartmentName = d.DepName,
                                Salary = s.SalaryAmount,
                                AccountHolderName = a.AccHolderName,
                                AccountType = a.AccType
                            };
            
             return JoinQuery; */

            /*var leftJoinQuery = from e in Emp
                        join d in Dep on e.DepartmentID equals d.DepartmentId into empDept
                        join s in Salary on e.EmpID equals s.EmpID into empSalary
                        join a in Account on empSalary.FirstOrDefault()?.SalaryId equals a.SalaryId into empAccount
                        select new
                        {
                            EmployeeName = e.EmpName,
                            EmployeeAge = e.EmpAge,
                            Department = empDept.FirstOrDefault()?.DepName,
                            Salary = empSalary.FirstOrDefault()?.SalaryAmount,
                            AccountHolderName = empAccount.FirstOrDefault()?.AccHolderName,
                            AccountType = empAccount.FirstOrDefault()?.AccType
                        };
            
             return leftJoinQuery;*/
            var rightJoinQuery = from d in Dep
                        join e in Emp on d.DepartmentId equals e.DepartmentID into empDept
                        from department in empDept.DefaultIfEmpty()
                        join s in Salary on department?.EmpID equals s.EmpID into empSalary
                        from salary in empSalary.DefaultIfEmpty()
                        join a in Account on salary?.SalaryId equals a.SalaryId into empAccount
                        from account in empAccount.DefaultIfEmpty()
                        select new
                        {
                            EmployeeName = department?.EmpName,
                            EmployeeAge = department?.EmpAge,
                            Department = d.DepName,
                            Salary = salary?.SalaryAmount,
                            AccountHolderName = account?.AccHolderName,
                            AccountType = account?.AccType
                        };
            return rightJoinQuery;
        }

    }
}
