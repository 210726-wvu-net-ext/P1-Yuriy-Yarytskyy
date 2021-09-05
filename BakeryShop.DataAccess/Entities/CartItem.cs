using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

#nullable disable

namespace BakeryShop.DataAccess.Entities
{
    public partial class CartItem
    {
        public CartItem()
        {
            // required by EF
        }
        public CartItem(int itemId, int quantity, decimal unitPrice)
        {
            ItemId = itemId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public int Id { get; set; }
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Guid ShopCartId { get; set; }


        [JsonIgnore]
        public ShoppingCart Cart { get; set; }
    }
}
