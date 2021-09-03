using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Entities;

namespace BakeryShop.WebApp.Interfaces
{
    public interface IUserAccessor
    {
        User GetUser();
    }
}
