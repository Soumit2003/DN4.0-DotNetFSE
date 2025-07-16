using Microsoft.AspNetCore.Mvc;
using Experiment3.Models;
using Experiment3.Filters;
namespace Experiment3.Controllers
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
    }
}
