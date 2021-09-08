using System;
using System.Collections.Generic;

#nullable disable

namespace BakeryShop.DataAccess.Entities
{
    public partial class ItemCategory
    {
       

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Item> Items { get; set; }
    }
}
