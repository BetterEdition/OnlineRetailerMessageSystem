﻿using System.Collections.Generic;
using System.Linq;
using SharedModels;
using System;

namespace CustomersApi.Data
{
    public class DbInitializer : IDbInitializer
    {
        // This method will create and seed the database.
        public void Initialize(CustomerApiContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Products
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            List<Customer> customers = new List<Customer>
            {
                new Customer {  }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
