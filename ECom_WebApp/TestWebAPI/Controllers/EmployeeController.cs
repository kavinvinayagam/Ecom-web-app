using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Data;
using TestWebAPI.Models.Entities;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly APIDbContext _dbContext;

        public EmployeeController(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = _dbContext.Employee.ToList();

            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        public IActionResult GetEmployeeById(Guid Id)
        {
            var employee = _dbContext.Employee.Find(Id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            var emploi = new Employee
            {
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
            };

            _dbContext.Employee.Add(emploi);
            return Ok(emploi);
        }

        [HttpPut]
        [Route("{Id:guid}")]
        public IActionResult UpdateEmployee(Guid Id, Employee employee)

        {
            var employeeee = _dbContext.Employee.Find(Id);
            if (employeeee is null)
            {
                return NotFound();
            }
            employeeee.Name = employee.Name;
            employeeee.Phone = employee.Phone;
            employeeee.Email = employee.Email;

            return Ok();

        }
        
    }
}
