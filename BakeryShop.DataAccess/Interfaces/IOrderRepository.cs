using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Entities;
using BakeryShop.DataAccess.Models;

namespace BakeryShop.DataAccess.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetUserOrders(int UserId);
        OrderModel GetOrderDetails(string id);
        //PagingListModel<OrderModel> GetOrderList(int page, int pageSize);
    }
}