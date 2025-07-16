using Microsoft.AspNetCore.Mvc;
using Experiment4.Models;
using Experiment4.Filters;
namespace Experiment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        private readonly List<Employee> _employees;

        public EmployeeController()
        {
            _employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Soumit Roy",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "Engineering" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "ASP.NET" }
                    },
                    DateOfBirth = new DateTime(1999, 1, 1)
                }
            };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> Get()
        {
            throw new Exception("Simulated crash for testing the exception filter.");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return BadRequest("Invalid employee id");

            employee.Name = updatedEmp.Name;
            employee.Salary = updatedEmp.Salary;
            employee.Permanent = updatedEmp.Permanent;
            employee.Department = updatedEmp.Department;
            employee.Skills = updatedEmp.Skills;
            employee.DateOfBirth = updatedEmp.DateOfBirth;

            return Ok(employee);
        }

    }

}
