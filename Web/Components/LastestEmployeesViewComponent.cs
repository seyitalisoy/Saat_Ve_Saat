using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Web.Components
{
    public class LastestEmployeesViewComponent : ViewComponent
    {
        IEmployeeService _employeeService;

        public LastestEmployeesViewComponent(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _employeeService.GetLastestEmployees();
            return View(result);
        }
    }
}
