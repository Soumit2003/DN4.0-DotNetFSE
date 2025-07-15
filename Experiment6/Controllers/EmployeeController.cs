using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Experiment5.Models;

namespace Experiment5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,POC")]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> _employees;

        public EmployeeController()
        {
            _employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Soumit",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 101, Name = "Engineering" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "SQL" }
                    },
                    DateOfBirth = new DateTime(2000, 5, 1)
                }
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employees);
        }
    }
}
