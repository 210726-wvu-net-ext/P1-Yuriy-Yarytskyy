using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BakeryShop.WebApp.ViewComponents
{
    public class BakeryShopMenuViewComponent : ViewComponent
    {
        ICatalogService _catalogService;
        public BakeryShopMenuViewComponent(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public IViewComponentResult Invoke()
        {
            var items = _catalogService.GetItems();
            return View("~/Views/Shared/_BakeryShopMenu.cshtml", items);
        }
    }
}
