using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Entities;
using BakeryShop.DataAccess.Models;

namespace BakeryShop.DataAccess.Interfaces
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        ShoppingCart GetCart(Guid CartId);
        ShoppingCartModel GetCartDetails(Guid CartId);
        int DeleteItem(Guid cartId, int itemId);
        int UpdateQuantity(Guid cartId, int itemId, int Quantity);
        int UpdateCart(Guid cartId, int userId);
        
    }
}