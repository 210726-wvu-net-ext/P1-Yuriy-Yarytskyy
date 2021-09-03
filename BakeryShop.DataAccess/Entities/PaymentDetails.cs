using System;
using System.Collections.Generic;

#nullable disable

namespace BakeryShop.DataAccess.Entities
{
    public class PaymentDetails
    {
        public PaymentDetails()
        {
            
        }
        public string Id { get; set; }
        public string TransactionId { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int ShoppingCartId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public decimal GrandTotal { get; set; }
    }
}