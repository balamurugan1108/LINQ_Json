using Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LINQ_TableMapping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Emp_DetailsController : ControllerBase
    {
        private readonly IEmployeeCls _employeeCls;
        public Emp_DetailsController(IEmployeeCls employeeCls)
        {
            _employeeCls = employeeCls;
        }
        [HttpGet("EmployeeDetails")]
        public  IActionResult getEmpDetails()
        {
            return Ok(_employeeCls.getEmpDetails());
        }
    }
}
