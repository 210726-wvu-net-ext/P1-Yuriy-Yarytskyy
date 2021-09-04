using BakeryShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryShop.Domain.Interfaces
{
    public interface ICatalogService
    {
        IEnumerable<ItemCategory> GetCategories();
        IEnumerable<Item> GetItems();
        IEnumerable<Inventory> GetInventory();
        Item GetItem(int id);
        void AddItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int id);
    }
}
