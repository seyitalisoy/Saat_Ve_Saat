using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        IDepartmenService _departmenService;

        public DepartmentsController(IDepartmenService departmenService)
        {
            _departmenService = departmenService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _departmenService.GetAll();
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Department department)
        {
            _departmenService.Add(department);
            var result = _departmenService.GetById(department.DepartmentId);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
