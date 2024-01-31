using Infrastructure.DataBase.Tables;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.DataBase
{
    public class DataBaseContext : DbContext // Create interface if you want to add custom methods
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) 
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; } // table in the database
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var customer1 = new Customer
            {
                CustomerId = 1,
                FirstName = "Bobby",
                SurName = "Bob",
                Address = "1 Bob Street",
                City = "Bob Town",
                Email = "bobby.bob@gmail.com",
                Phone = "01222222",
                Balance = 1000
            };

            var customer2 = new Customer
            {
                CustomerId = 2,
                FirstName = "Franky",
                SurName = "Frank",
                Address = "1 Frank Street",
                City = "Frank Town",
                Email = "franky.frank@gmail.com",
                Phone = "0133333",
                Balance = 2
            };

            var order1 = new Order
            {
                OrderId = 1001,
                CustomerId = 1,
                WineType = "Red",
                WineName = "Chianti",
                WineQuantity = 2,
                WinePrice = 30,
                TanicLevelOutOfTen = 3,
                CreatedAt = new DateTime(2023, 10, 20),
                LastUpdated = new DateTime(2023, 10, 20),
            };

            modelBuilder.Entity<Customer>().HasData(customer1, customer2);
            modelBuilder.Entity<Order>().HasData(order1);

            base.OnModelCreating(modelBuilder);
        }
    }
}
