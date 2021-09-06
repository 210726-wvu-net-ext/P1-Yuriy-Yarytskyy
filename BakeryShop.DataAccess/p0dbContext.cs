
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using BakeryShop.DataAccess.Entities;

namespace BakeryShop.DataAccess
{
    public class p0dbContext : IdentityDbContext<User, Role, int>
    {
        //needed for migration
        public p0dbContext()
        {

        }
        //configuration from settings
        public p0dbContext(DbContextOptions<p0dbContext> options): base(options)
        {

        }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Address> Address { get; set; }

        public virtual DbSet<PaymentDetails> PaymentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //needed for migration
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:rev-yyarytskyy.database.windows.net,1433;Initial Catalog=p0db;Persist Security Info=False;User ID=petadmin;Password=R@spberryPi4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
