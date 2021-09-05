using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Entities;
using BakeryShop.DataAccess.Implementation;
using BakeryShop.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BakeryShop.Domain.Configuration
{
    public class ConfigureRepositories
    {
        //dependency injection for DL
        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<p1dbContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));

            });
            services.AddIdentity<User, Role>().
                AddEntityFrameworkStores<p1dbContext>().AddDefaultTokenProviders();
            services.AddScoped<DbContext, p1dbContext>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();

            services.AddTransient<IRepository<Item>, Repository<Item>>();
            services.AddTransient<IRepository<ItemCategory>, Repository<ItemCategory>>();
            services.AddTransient<IRepository<Inventory>, Repository<Inventory>>();
            services.AddTransient<IRepository<ShoppingCart>, Repository<ShoppingCart>>();
            services.AddTransient<IRepository<Order>, Repository<Order>>();
            services.AddTransient<IRepository<Role>, Repository<Role>>();
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Location>, Repository<Location>>();
            services.AddTransient<IRepository<CartItem>, Repository<CartItem>>();
            services.AddTransient<IRepository<OrderItem>, Repository<OrderItem>>();
            services.AddTransient<IRepository<PaymentDetails>, Repository<PaymentDetails>>();

        }
    }
}
