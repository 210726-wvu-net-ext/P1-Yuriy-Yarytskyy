using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Entities;
using BakeryShop.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using BakeryShop.Domain.Interfaces;
//using IAuthenticationService = Microsoft.AspNetCore.Authentication.IAuthenticationService;
using IAuthenticationService = BakeryShop.Domain.Interfaces.IAuthenticationService;

namespace BakeryShop.WebApp.Controllers
{
    public class AccountController : Controller
    {
        //dependency injection
        IAuthenticationService _authService;

        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }
       

        [HttpPost]
        public IActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _authService.AuthenticateUser(model.Email, model.Password);
                if (user != null)
                {
                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else if (user.Roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "User" });
                    }
                }
            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                bool result = _authService.CreateUser(user, model.Password);
                if (result)
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _authService.SignOut();
            return RedirectToAction("LogOutComplete");
        }

        public IActionResult LogOutComplete()
        {
            return View();
        }
        public IActionResult Unauthorized()
        {
            return View();
        }
    }
}
