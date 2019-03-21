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
          

            List<Product> products = new List<Product>
            {
                new Product{Id = 1,ItemsInStock = 2, ItemsReserved = 0, Name="hammer1", Price= 23,OrderedProduct = 1 },
                new Product{Id = 2,ItemsInStock = 2, ItemsReserved = 0, Name="hammer2", Price= 23, OrderedProduct = 1  },
                new Product{Id = 3,ItemsInStock = 2, ItemsReserved = 0, Name="hammer3", Price= 23, OrderedProduct = 1  },
               
            };



            List<Order> orders = new List<Order>
            {
                new Order { Date = DateTime.Today, Id=1, Products = products}

                new Order { Date = DateTime.Today, ProductsOrdered = new List<ProductOrder> { { new ProductOrder { Id = 1, Quantity = 3 } } } }
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
