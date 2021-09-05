﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Entities;
using BakeryShop.WebApp.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BakeryShop.WebApp.Controllers
{
    public class BaseController : Controller
    {
        protected UserManager<User> _userManager;
        public User CurrentUser
        {
            get
            {
                if (User.Identity.Name != null)
                    return _userManager.FindByNameAsync(User.Identity.Name).Result;
                else
                    return null;
            }
        }

        
        public BaseController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
    }
}

