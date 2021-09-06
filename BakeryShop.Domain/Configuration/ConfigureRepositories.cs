using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryShop.DataAccess;
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
            services.AddDbContext<p0dbContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));

            });
            services.AddIdentity<User, Role>().
                AddEntityFrameworkStores<p0dbContext>().AddDefaultTokenProviders();
            services.AddScoped<DbContext, p0dbContext>();

            
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IRepository<Item>, Repository<Item>>();
            services.AddTransient<IRepository<ItemCategory>, Repository<ItemCategory>>();
            services.AddTransient<IRepository<Inventory>, Repository<Inventory>>();
            services.AddTransient<IRepository<CartItem>, Repository<CartItem>>();

        }
    }
}
