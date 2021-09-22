using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Entities;
using BakeryShop.DataAccess.Models;

namespace BakeryShop.Domain.Interfaces
{
    public interface IOrderService
    {
        OrderModel GetOrderDetails(string OrderId);
        IEnumerable<Order> GetUserOrders(int UserId);
        int PlaceOrder(int userId, string orderId, string paymentId, CartModel cart, Address address);
<<<<<<< HEAD
        //PagingListModel<OrderModel> GetOrderList(int page = 1, int pageSize = 10);
=======
       
>>>>>>> 54966e0325f6b567a459831c54ee7e468a3fada7
    }
}
