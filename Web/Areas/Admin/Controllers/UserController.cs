using Business.Abstract;
using Web.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Areas.Admin.Models;
using Web.Controllers;
using Web.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IPositionService _positionService;
        private readonly IDepartmenService _departmenService;
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserController(IPositionService positionService, IDepartmenService departmenService, IEmployeeService employeeService, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _positionService = positionService;
            _departmenService = departmenService;
            _employeeService = employeeService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> UserList()
        {
            var userList = await _userManager.Users.ToListAsync();
            var userViewModelList = userList.Select(x => new UserViewModel
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.UserName
            }).ToList();


            return View(userViewModelList);
        }

        public IActionResult UserCreate()
        {
            ViewBag.Positions = new SelectList(_positionService.GetAll(),
                "PositionId", "PositionName", "1");

            ViewBag.Departments = new SelectList(_departmenService.GetAll(),
                "DepartmentId", "DepartmentName", "1");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserCreate(UserCreateViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(UserController.UserCreate));
            }

            var identityResult = await _userManager.CreateAsync(new()
            {
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.Phone,
            }, request.PasswordConfirm);


            if (!identityResult.Succeeded)
            {
                ModelState.AddModelErrorList(identityResult.Errors);
                return View();
            }
            

            _employeeService.Add(new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DepartmentId = request.DepartmentId,
                PositionId = request.PositionId,
                BirthDay = request.BirthDay,
                DateOfHire = request.DateOfHire,
                PhoneNumber = request.Phone,
                TcNo = request.TcNo
            });

            TempData["SuccessMessage"] = "Üyelik kayıt işlemi başarılı.";
            return RedirectToAction(nameof(UserController.UserCreate));
        }
    }
}
