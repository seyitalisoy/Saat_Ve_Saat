using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;
using Web.Models;
using Web.Extensions;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmployeeService _employeeService;
        private readonly IFileProvider _fileProvider;
        public MemberController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IEmployeeService employeeService, IFileProvider fileProvider)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _employeeService = employeeService;
            _fileProvider = fileProvider;
        }

        public  async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var userViewModel = new UserViewModel
            {
                Email = currentUser!.Email,
                UserName = currentUser!.UserName,
                PhoneNumber = currentUser!.PhoneNumber,
                PictureUrl = currentUser!.Picture
            };
            return View(userViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var checkOldPassword = await _userManager.CheckPasswordAsync(currentUser!, request.PasswordOld);

            if (!checkOldPassword)
            {
                ModelState.AddModelError(string.Empty, "Eski şifreniz yanlış");
                return View();
            }
            var resultChangePassword = await _userManager.ChangePasswordAsync(currentUser!,
                request.PasswordOld, request.PasswordNew);

            if (!resultChangePassword.Succeeded)
            {
                ModelState.AddModelErrorList(resultChangePassword.Errors);
            }


            await _userManager.UpdateSecurityStampAsync(currentUser!);
            await _signInManager.SignOutAsync();
            await _signInManager.PasswordSignInAsync(currentUser!, request.PasswordNew, true, false);

            TempData["SuccessMessage"] = "Şifreniz başarıyla değiştirilmiştir";

            return RedirectToAction(nameof(PasswordChange));
        }

        public async Task<IActionResult> UserEdit()
        {
            var currentUser = await _userManager.FindByNameAsync(User?.Identity?.Name!);
            var employees = _employeeService.GetAll();
            var currentEmployee = employees.FirstOrDefault(e => e.PhoneNumber==currentUser!.PhoneNumber);

            TempData["EmployeeId"] = currentEmployee!.EmployeeId;

            var userEditViewModel = new UserEditViewModel()
            {
                FirstName = currentEmployee!.FirstName,
                LastName = currentEmployee!.LastName,
                BirthDay = currentEmployee!.BirthDay,
                TcNo = currentEmployee!.TcNo,
                DateOfHire = currentEmployee!.DateOfHire,
                UserName = currentUser!.UserName!,
                Email = currentUser!.Email!,
                Phone = currentUser!.PhoneNumber!,                
                
            };
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditViewModel request)
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        // Hata mesajlarını loglayabilir veya hata sayfasına gönderebilirsiniz.
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

                return View();
            }

            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name!);
            currentUser!.UserName = request.UserName;
            currentUser.Email = request.Email;
            currentUser.PhoneNumber = request.Phone;

            var employeeId = int.Parse(Request.Form["employeeId"]);
            var currentEmployee = _employeeService.GetById(employeeId);
            currentEmployee.FirstName = request.FirstName;
            currentEmployee.LastName = request.LastName;
            currentEmployee.BirthDay = request.BirthDay;
            currentEmployee.DateOfHire = request.DateOfHire;
            currentEmployee.PhoneNumber = request.Phone;
            currentEmployee.TcNo = request.TcNo;
            _employeeService.Update(currentEmployee);


            if (request.Picture != null && request.Picture.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");

                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(request.Picture.FileName)}";
                //jpg,png vs
                var newPicturePath =
                    Path.Combine(wwwrootFolder.First(x => x.Name == "images").PhysicalPath!, randomFileName);

                using var stream = new FileStream(newPicturePath, FileMode.Create);

                await request.Picture.CopyToAsync(stream);

                currentUser.Picture = randomFileName;
            }
            var updateToUserResult = await _userManager.UpdateAsync(currentUser);
            if (!updateToUserResult.Succeeded)
            {
                ModelState.AddModelErrorList(updateToUserResult.Errors);
                return View();
            }

            await _userManager.UpdateSecurityStampAsync(currentUser);
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(currentUser, true);

            TempData["SuccessMessage"] = "Kullanıcı bilgileri güncellendi";

            return RedirectToAction(nameof(UserEdit));
        }

    }
}
