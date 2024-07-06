using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeesController : ControllerBase
    {
        private readonly AppDBContext dbContext;

        public EmployeesController(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);
        }
        [HttpPost]
        public IActionResult AddEmployees(AddEmployeeDTO addEmployeeDTO)
        {
            var employeeEntity = new Employees()
            {
                Name = addEmployeeDTO.Name,
                Email = addEmployeeDTO.Email,
                phone = addEmployeeDTO.phone,
                salary = addEmployeeDTO.salary
            };
            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();
            return Ok(employeeEntity);

        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return BadRequest("notfound");
            }
            return Ok(employee);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployee updateEmployee)
        {
            var foundemp = dbContext.Employees.Find(id);
            if (foundemp == null)
            {
                return NotFound();
            }
            foundemp.Name = updateEmployee.Name;
            foundemp.Email = updateEmployee.Email;
            foundemp.phone = updateEmployee.phone;
            foundemp.salary = updateEmployee.salary;
            dbContext.SaveChanges();
            return Ok(foundemp);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployeeById(Guid id)
        {
            var empfind= dbContext.Employees.Find(id);
            if (empfind == null) {
                return NotFound();
            }
            dbContext.Employees.Remove(empfind);
            dbContext.SaveChanges();
            return Ok(empfind);

        }
    }
}

