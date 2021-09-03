using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BakeryShop.DataAccess.Entities;
using BakeryShop.DataAccess.Interfaces;

namespace BakeryShop.DataAccess.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private p1dbContext appContext
        {
            get
            {
                return _dbContext as p1dbContext;
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
    }
}
