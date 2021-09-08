﻿using BakeryShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.Domain.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;

namespace BakeryShop.WebApp.Controllers
{
    
    public class HomeController : Controller
    {
        public ICatalogService _catalogService;
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        public object WithAnonymousIdentity()
        {
            throw new NotImplementedException();
        }

        public HomeController(NullLogger<HomeController> logger)
        {
        }

        public IActionResult Index()
        {
            var items = _catalogService.GetItems();
            return View(items);
        }

        public object WithIdentity(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
