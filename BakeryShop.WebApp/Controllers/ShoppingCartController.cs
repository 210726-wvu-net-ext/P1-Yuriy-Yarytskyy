using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using BakeryShop.DataAccess.Entities;
using BakeryShop.DataAccess.Interfaces;
using BakeryShop.DataAccess.Models;

namespace BakeryShop.WebApp.Controllers
{
    public class ShoppingCartController : BaseController
    {
        IShoppingCartService _shoppingCartService;

        Guid ShopCartId
        {
            get
            {
                Guid Id;
                string CId = Request.Cookies["CId"];
                if (string.IsNullOrEmpty(CId))
                {
                    Id = Guid.NewGuid();
                    Response.Cookies.Append("CId", Id.ToString());
                }
                else
                {
                    Id = Guid.Parse(CId);
                }

                return Id;
            }
        }

        public ShoppingCartController(IShoppingCartService shoppingCartService, UserManager<User> userManager) : base(userManager)
        {
            _shoppingCartService = shoppingCartService;
        }
        public IActionResult Index()
        {
            ShoppingCartModel cart = _shoppingCartService.GetCartDetails(ShopCartId);
            //if (CurrentUser != null && cart != null)
            //{
            //    TempData.Set("Cart", cart);
            //    _shoppingCartService.UpdateCart(cart.Id, CurrentUser.Id);
            //}
            return View(cart);

        }
        [Route("Cart/AddToCart/{ItemId}/{UnitPrice}/{Quantity}")]
        public IActionResult AddToCart(int ItemId, decimal UnitPrice, int Quantity)
        {
            int UserId = CurrentUser != null ? CurrentUser.Id : 0;

            if (ItemId > 0 && Quantity > 0)
            {
                ShoppingCart cart = _shoppingCartService.AddItem(UserId, ShopCartId, ItemId, UnitPrice, Quantity);
                var data = JsonSerializer.Serialize(cart);
                return Json(data);
            }
            else
            {
                return Json("");
            }
        }

        public IActionResult DeleteItem(int Id)
        {
            int count = _shoppingCartService.DeleteItem(ShopCartId, Id);
            return Json(count);
        }

        [Route("Cart/UpdateQuantity/{Id}/{Quantity}")]
        public IActionResult UpdateQuantity(int Id, int Quantity)
        {
            int count = _shoppingCartService.UpdateQuantity(ShopCartId, Id, Quantity);
            return Json(count);
        }
    }
}
