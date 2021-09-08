using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.WebApp.Interfaces;

namespace BakeryShop.WebApp.Areas.User.Controllers
{
    public class DashboardController : BaseController
    {
        public DashboardController(IUserAccessor userAccessor) : base(userAccessor)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
