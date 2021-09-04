using BakeryShop.DataAccess.Entities;
using BakeryShop.DataAccess.Interfaces;
using BakeryShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryShop.Domain.Implementation
{
    public class CatalogService : ICatalogService
    {

        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<ItemCategory> _categoryRepository;
        private readonly IRepository<Inventory> _inventoryRepository;
        public CatalogService(IRepository<Item> itemRepository, IRepository<ItemCategory> categoryRepository, IRepository<Inventory> inventoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _inventoryRepository = inventoryRepository;
        }
        public void AddItem(Item item)
        {
            _itemRepository.Add(item);
            _itemRepository.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            _itemRepository.Delete(id);
            _itemRepository.SaveChanges();
        }

        public IEnumerable<ItemCategory> GetCategories()
        {
            return _categoryRepository.GetAll();
        }

        public Item GetItem(int id)
        {
            return _itemRepository.Find(id);
        }
        
        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetAll().OrderBy(item => item.ItemCategoryId);
        }

        public IEnumerable<Inventory> GetInventory()
        {
            return _inventoryRepository.GetAll();
        }

        public void UpdateItem(Item item)
        {
            _itemRepository.Update(item);
            _itemRepository.SaveChanges();
        }
    }
}
