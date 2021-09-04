using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Entities;
using BakeryShop.Domain.Interfaces;
using BakeryShop.WebApp.Interfaces;
using BakeryShop.WebApp.Models;

namespace BakeryShop.WebApp.Areas.Admin.Controllers
{
    public class ItemController : BaseController
    {
        ICatalogService _catalogService;
        IFileHelper _fileHelper;

        public ItemController(ICatalogService catalogService, IFileHelper fileHelper)
        {
            _catalogService = catalogService;
            _fileHelper = fileHelper;
        }
        public IActionResult Index()
        {
            var data = _catalogService.GetItems();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _catalogService.GetCategories();
            ViewBag.ItemTypes = _catalogService.GetInventory();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ItemModel model)
        {
            try
            {
                model.ImageUrl = _fileHelper.UploadFile(model.File);
                Item data = new Item
                {
                    Name = model.Name,
                    UnitPrice = model.UnitPrice,
                    ItemCategoryId = model.CategoryId,
                    //InventoryId = model.InventoryId,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl
                };
                _catalogService.AddItem(data);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

            }
            ViewBag.Categories = _catalogService.GetCategories();
            ViewBag.ItemTypes = _catalogService.GetInventory();
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _catalogService.GetCategories();
            ViewBag.ItemTypes = _catalogService.GetInventory();
            Item data = _catalogService.GetItem(id);
            ItemModel model = new ItemModel
            {
                Id = data.Id,
                Name = data.Name,
                UnitPrice = (decimal)data.UnitPrice,
                CategoryId = data.ItemCategoryId,
                //InventoryId = data.InventoryId,
                Description = data.Description,
                ImageUrl = data.ImageUrl
            };
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(ItemModel model)
        {
            try
            {
                if (model.File != null)
                {
                    _fileHelper.DeleteFile(model.ImageUrl);
                    model.ImageUrl = _fileHelper.UploadFile(model.File);
                }

                Item data = new Item
                {
                    Id = model.Id,
                    Name = model.Name,
                    UnitPrice = model.UnitPrice,
                    ItemCategoryId = model.CategoryId,
                    //InventoryId = model.InventoryId,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl
                };

                _catalogService.UpdateItem(data);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }
            ViewBag.Categories = _catalogService.GetCategories();
            ViewBag.ItemTypes = _catalogService.GetInventory();
            return View("Create", model);
        }

        [Route("~/Admin/Item/Delete/{id}/{url}")]
        public IActionResult Delete(int id, string url)
        {
            url = url.Replace("%2F", "/"); //replace to find the file

            _catalogService.DeleteItem(id);
            _fileHelper.DeleteFile(url);
            return RedirectToAction("Index");
        }
    }
}
