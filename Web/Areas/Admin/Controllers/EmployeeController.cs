using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmenService _departmenService;

        public EmployeeController(IEmployeeService employeeService, IDepartmenService departmenService)
        {
            _employeeService = employeeService;
            _departmenService = departmenService;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            var result = _employeeService.GetAll();
            return View(result);
        }

        [Area("Admin")]
        public IActionResult DepartmentList()
        {
            var result = _departmenService.GetAll();
            return View(result);
        }
    }

}
