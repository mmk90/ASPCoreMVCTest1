using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Website.Data.Repositories;
using Website.Models;

namespace Website.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userRepository.IsExistUserByEmail(register.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده قبلا ثبت نام کرده است");
                return View(register);
            }

            User user = new User()
            {
                Email = register.Email.ToLower(),
                Password = register.Password,
                IsAdmin = false,
                RegisterDate = DateTime.Now
            };

            _userRepository.AddUser(user);

            return View("SuccessRegister", register);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid==false)
            {
                return View(model);
            }

            var user = _userRepository.GetUserForLogin(model.Email, model.Password);

            if(user==null)
            {
                ModelState.AddModelError("Email", "نام کاربری یا رمز عبور صحیح نمیباشد");
                return View(model);
            }

            var cliams = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.Email)
            };

            var claimIdentity = new ClaimsIdentity(cliams, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimPrincipal = new ClaimsPrincipal(claimIdentity);

            var properties = new AuthenticationProperties()
            {
                IsPersistent = model.RememberMe
            };

            HttpContext.SignInAsync(claimPrincipal, properties);

            return Redirect("/");
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
    }
}
