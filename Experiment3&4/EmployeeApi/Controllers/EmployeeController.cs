using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using EmployeeApi.Filters;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [TypeFilter(typeof(CustomAuthFilter))]

    public class EmployeeController : ControllerBase
    {
        private List<Employee> _employees;

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

        // ✅ HTTP GET
        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> Get()
        {
            throw new Exception("This is a test crash.");
        }

        // ✅ HTTP POST
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            _employees.Add(employee);
            return Ok(employee);
        }

        // ✅ HTTP PUT
        [HttpPut]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(400)]
        public ActionResult<Employee> Put([FromBody] Employee employee)
        {
            if (employee.Id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existing = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing == null)
            {
                return BadRequest("Invalid employee id");
            }

            //  employee
            existing.Name = employee.Name;
            existing.Salary = employee.Salary;
            existing.Permanent = employee.Permanent;
            existing.Department = employee.Department;
            existing.Skills = employee.Skills;
            existing.DateOfBirth = employee.DateOfBirth;

            return Ok(existing);
        }

        // ✅ HTTP DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return BadRequest("Invalid employee id");
            }

            _employees.Remove(employee);
            return Ok($"Employee with ID {id} deleted successfully.");
        }
    }
}
