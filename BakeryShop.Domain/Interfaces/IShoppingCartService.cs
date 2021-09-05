using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Entities;
using BakeryShop.DataAccess.Models;

namespace BakeryShop.DataAccess.Interfaces
{
    public interface IShoppingCartService
    {
        int GetCartCount(Guid cartId);
        ShoppingCartModel GetCartDetails(Guid cartId);
        ShoppingCart AddItem(int UserId, Guid CartId, int ItemId, decimal UnitPrice, int Quantity);
        int DeleteItem(Guid cartId, int ItemId);
        int UpdateQuantity(Guid cartId, int id, int quantity);
        int UpdateCart(Guid CartId, int UserId);
        
    }
}
