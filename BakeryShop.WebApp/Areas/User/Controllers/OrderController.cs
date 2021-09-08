﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Models;
using BakeryShop.Domain.Interfaces;
using BakeryShop.WebApp.Interfaces;

namespace BakeryShop.WebApp.Areas.User.Controllers
{
    public class OrderController : BaseController
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService, IUserAccessor userAccessor) : base(userAccessor)

        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            var orders = _orderService.GetUserOrders(CurrentUser.Id);
            return View(orders);
        }

        [Route("~/User/Order/Details/{OrderId}")]
        public IActionResult Details(string OrderId)
        {
            OrderModel Order = _orderService.GetOrderDetails(OrderId);
            return View(Order);
        }
    }
}
