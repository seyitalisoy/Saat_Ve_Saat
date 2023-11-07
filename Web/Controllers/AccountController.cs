using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Extensions;
using Web.Models;
using Web.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel request, string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var userResult = await _userManager.FindByEmailAsync(request.Email);

            if (userResult == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış");
            }

            var signInResult = await _signInManager.PasswordSignInAsync(userResult!, request.Password, request.RememberMe, true);

            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl!);
            }

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "1 dakika boyunca giriş yapamazsınız.");
            }

            ModelState.AddModelError(string.Empty, "Email veya şifre yanlış");

            return View();
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel request)
        {
            var userResult = await _userManager.FindByEmailAsync(request.Email!);

            if (userResult == null)
            {
                ModelState.AddModelError(string.Empty, "Bu Email adresine sahip kullanıcı bulunamamıştır");
                return View();
            }

            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(userResult);

            var passwordResetLink = Url.Action("ResetPassword", "Home", new
            {
                userId = userResult.Id,
                Token = passwordResetToken
            }
            , HttpContext.Request.Scheme);

            await _emailService.SendResetPasswordEmail(passwordResetLink!, userResult.Email!);

            TempData["SuccessMessage"] = "Şifre yenileme linki gönderildi";

            return RedirectToAction(nameof(ForgetPassword));
        }

        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];

            if (userId == null || token == null)
            {
                throw new Exception("Bir hata oluştu.");
            }

            var userResult = await _userManager.FindByIdAsync(userId.ToString()!);

            if (userResult == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bulunamamıştır");
                return View();
            }
            var result = await _userManager.ResetPasswordAsync(userResult, token.ToString()!, request.Password);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Şifreniz başarıyla yenilenmiştir.";
            }
            else
            {
                ModelState.AddModelErrorList(result.Errors);
            }

            return RedirectToAction(nameof(ResetPassword));
        }
    }
}
