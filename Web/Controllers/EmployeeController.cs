using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        IEmployeeService _employeeService;
        IDepartmenService _departmenService;

        public EmployeeController(IEmployeeService employeeService, IDepartmenService departmenService)
        {
            _employeeService = employeeService;
            _departmenService = departmenService;
        }

        public IActionResult Index()
        {
            var result = _employeeService.GetAll();
            return View(result);
        }

        public IActionResult DepartmentList()
        {
            var result = _departmenService.GetAll();
            return View(result);
        }
    }
}
