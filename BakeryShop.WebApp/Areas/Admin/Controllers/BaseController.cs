using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Entities;
using BakeryShop.WebApp.Helpers;

namespace BakeryShop.WebApp.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles ="Admin")]
    [Area("Admin")]
    public class BaseController : Controller
    {
        
    }
}
