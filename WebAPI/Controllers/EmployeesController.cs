using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetById(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result= _employeeService.GetAll();
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Employee employee)
        {   
            _employeeService.Add(employee);
            var result = _employeeService.GetById(employee.EmployeeId);
            if (result is null)
            {
                return NotFound();
            }  
            return Ok(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _employeeService.GetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _employeeService.Delete(result);
            return Ok(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Employee employee)
        {
            var result = _employeeService.GetById(employee.EmployeeId);
            if (result is null)
            {
                return NotFound();
            }
            _employeeService.Update(employee);
            return Ok(employee);
        }


    }
}
