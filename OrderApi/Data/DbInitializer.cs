using System.Collections.Generic;
using System.Linq;
using SharedModels;
using System;

namespace OrderApi.Data
{
    public class DbInitializer : IDbInitializer
    {
        // This method will create and seed the database.
        public void Initialize(OrderApiContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Products
            if (context.Orders.Any())
            {
                return;   // DB has been seeded
            }

            List<ProductOrder> productOrders = new List<ProductOrder>
            {
                new ProductOrder { ProductId = 1, Quantity = 1 },
                new ProductOrder { ProductId = 2, Quantity = 1 }
            };

            List<Order> orders = new List<Order>
            {
                new Order { Date = DateTime.Today, Product = productOrders}
            };
         

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
