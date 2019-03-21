using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace CustomersApi.Data
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly CustomerApiContext db;

    public CustomerRepository(CustomerApiContext context)
    {
        db = context;
    }

    Customer IRepository<Customer>.Add(Customer entity)
    {
        var newCust = db.Customers.Add(entity).Entity;
        db.SaveChanges();
        return newCust;
    }

    void IRepository<Customer>.Edit(Customer entity)
    {
        db.Entry(entity).State = EntityState.Modified;
        db.SaveChanges();
    }

    Customer IRepository<Customer>.Get(int id)
    {
        return db.Customers.FirstOrDefault(p => p.Id == id);
    }

    IEnumerable<Customer> IRepository<Customer>.GetAll()
    {
        return db.Customers.ToList();
    }

    void IRepository<Customer>.Remove(int id)
    {
        var customer = db.Customers.FirstOrDefault(p => p.Id == id);
        db.Customers.Remove(customer);
        db.SaveChanges();
    }
    
    }
}
