using BakeryShop.DataAccess.Entities;
using BakeryShop.DataAccess.Interfaces;
using BakeryShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryShop.DataAccess.Implementation
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private p1dbContext appContext
        {
            get { return _dbContext as p1dbContext; }
        }

        public ShoppingCartRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public ShoppingCart GetCart(Guid CartId)
        {
            return appContext.ShoppingCarts.Include("Items").Where(c => c.Id == CartId && c.IsActive == true).FirstOrDefault();
        }

        public int DeleteItem(Guid cartId, int itemId)
        {
            var item = appContext.CartItems.Where(ci => ci.ShopCartId == cartId && ci.Id == itemId).FirstOrDefault();
            if (item != null)
            {
                appContext.CartItems.Remove(item);
                return appContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public int UpdateQuantity(Guid cartId, int itemId, int Quantity)
        {
            bool flag = false;
            var cart = GetCart(cartId);
            if (cart != null)
            {
                for (int i = 0; i < cart.CartItems.Count; i++)
                {
                    if (cart.CartItems[i].Id == itemId)
                    {
                        flag = true;
                        //for minus quantity
                        if (Quantity < 0 && cart.CartItems[i].Quantity > 1)
                            cart.CartItems[i].Quantity += (Quantity);
                        else if (Quantity > 0)
                            cart.CartItems[i].Quantity += (Quantity);
                        break;
                    }
                }
                if (flag)
                    return appContext.SaveChanges();
            }
            return 0;
        }

        public int UpdateCart(Guid cartId, int userId)
        {
            ShoppingCart cart = GetCart(cartId);
            cart.UserId = userId;
            return appContext.SaveChanges();
        }

        public ShoppingCartModel GetCartDetails(Guid CartId)
        {
            var model = (from cart in appContext.ShoppingCarts
                         where cart.Id == CartId && cart.IsActive == true
                         select new ShoppingCartModel
                         {
                             Id = cart.Id,
                             UserId = cart.UserId,
                             CreatedDate = cart.CreatedDate,
                             Items = (from cartItem in appContext.CartItems
                                      join item in appContext.Items
                                      on cartItem.ItemId equals item.Id
                                      where cartItem.ShopCartId == CartId
                                      select new ItemModel
                                      {
                                          Id = cartItem.Id,
                                          Name = item.Name,
                                          Description = item.Description,
                                          ImageUrl = item.ImageUrl,
                                          Quantity = cartItem.Quantity,
                                          ItemId = item.Id,
                                          UnitPrice = cartItem.UnitPrice
                                      }).ToList()
                         }).FirstOrDefault();
            return model;
        }
    }
}


