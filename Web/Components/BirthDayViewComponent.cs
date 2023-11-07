using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

namespace Web.Components
{
    public class BirthDayViewComponent : ViewComponent
    {
        IEmployeeService _employeeService;

        public BirthDayViewComponent(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IViewComponentResult Invoke()
        {
            var result = _employeeService.GetAllByBirthDayForThisWeek();
            return View(result);
        }
    }
}
