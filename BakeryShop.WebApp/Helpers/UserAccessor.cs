using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Entities;
using BakeryShop.WebApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BakeryShop.WebApp.Helpers
{
    public class UserAccessor : IUserAccessor
    {
        private readonly UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        public UserAccessor(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public User GetUser()
        {
            //logged in user and user name, does not contain complete user object
            if (_httpContextAccessor.HttpContext.User != null)
                //this userManager.GetUserAsync is fetching complete user object
                return _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            else
                return null;
        }
    }
}
