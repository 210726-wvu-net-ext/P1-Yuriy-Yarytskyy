using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BakeryShop.DataAccess.Entities;
using BakeryShop.DataAccess.Interfaces;
using BakeryShop.DataAccess.Models;
using System.Text;



namespace BakeryShop.DataAccess.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private p0dbContext appContext
        {
            get
            {
                return _dbContext as p0dbContext;
            }
        }
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {

        }
        //returning user orders based on user id
        public IEnumerable<Order> GetUserOrders(int UserId)
        {
            return appContext.Orders
               .Include(o => o.OrderItems)
               .Where(x => x.UserId == UserId).ToList();
        }

        public OrderModel GetOrderDetails(string orderId)
        {
            var model = (from order in appContext.Orders
                         where order.Id == orderId
                         select new OrderModel
                         {
                             Id = order.Id,
                             UserId = order.UserId,
                             CreatedDate = order.CreatedDate,
                             Items = (from orderItem in appContext.OrderItems
                                      join item in appContext.Items
                                      on orderItem.ItemId equals item.Id
                                      where orderItem.OrderId == orderId
                                      select new ItemModel
                                      {
                                          Id = orderItem.Id,
                                          Name = item.Name,
                                          Description = item.Description,
                                          ImageUrl = item.ImageUrl,
                                          Quantity = orderItem.Quantity,
                                          ItemId = item.Id,
                                          UnitPrice = orderItem.UnitPrice
                                      }).ToList()
                         }).FirstOrDefault();
            return model;
        }

    }
}
