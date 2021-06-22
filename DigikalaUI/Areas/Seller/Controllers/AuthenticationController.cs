using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DigikalaDataAccess;
using DigikalaDataAccess.Context;
using DigikalaRepository.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigikalaUI.Areas.Seller.Controllers
{
    [Area("seller")]
    public class AuthenticationController : Controller
    {
        HashSet<char> specialCharacters = new HashSet<char>() { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '-', '=' };
        Regex regex1 = new Regex("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{6,20}$");
        private readonly IUserRepository repository;
        DigikalaDB db;

        public AuthenticationController(IUserRepository repository)
        {
            this.repository = repository;
            db = new DigikalaDB();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (!ModelState.IsValid)
                return View();

            var result = repository.Login(user.UserName, user.UserPassword);

            if (result == null)
            {
                ViewBag.message = "نام کاربری یا رمز عبور صحیح نیست";
                return View();
            }
            setCookie(user.UserName, "Seller");

            return RedirectToAction("Indexpv", "Home", result);
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(User user)
        {
            if (!ModelState.IsValid)
                return View();

            if (db.Users.Where(x => x.UserName == user.UserName).FirstOrDefault() != null)
            {
                repository.ChangePassword(user);
                ViewBag.MessageS = "عملیات با موفقیت انجام شد";
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.MessageF = "نام کاربری وارد شده معتبر نیست";
                return View();
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string userName)
        {
            if (!ModelState.IsValid)
                return View();

            if (db.Users.Where(x => x.UserName == userName).FirstOrDefault() != null)
            {
                ViewBag.MessageS = "ایمیل بازیابی ارسال شد";
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.MessageF = "نام کاربری وارد شده معتبر نیست";
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
                return View();

            if (user.UserName.Any(specialCharacters.Contains))
            {
                ViewBag.MessageU = "نام کاربری شما حاوی کاراکتر های غیر مجاز است";
                return View();
            }

            if (!regex1.IsMatch(user.UserPassword))
            {
                ViewBag.MessageS = "رمز عبور شما ایمن نیست";
                return View();
            }

            repository.RegisterSeller(user.UserName, user.UserPassword);
            return RedirectToAction("Indexpv", "Home");
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        private void setCookie(string userName, string role)
        {
            var userClaims = new List<Claim>()
            {
            new Claim(ClaimTypes.Name,userName),
            new Claim(ClaimTypes.Role,role)
            };

            var grandmaIdentity = new ClaimsIdentity(userClaims, "هویت کاربر");

            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
            HttpContext.SignInAsync(userPrincipal);
        }
    }
}