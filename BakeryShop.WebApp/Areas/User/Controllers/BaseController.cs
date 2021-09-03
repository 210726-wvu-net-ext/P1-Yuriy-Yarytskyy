using BakeryShop.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.WebApp.Areas.User.Controllers
{
    public class BaseController : Controller
    {
        [CustomAuthorize(Roles = "User")]
        [Area("User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
