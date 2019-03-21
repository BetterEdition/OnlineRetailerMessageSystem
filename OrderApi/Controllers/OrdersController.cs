using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Data;
using SharedModels;
using RestSharp;
using EasyNetQ;
using OrderApi.Infrastructure;

namespace OrderApi.Controllers
{
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        IRepository<Order> repository;
        IServiceGateway<Product> productServiceGateway;
        IMessagePublisher messagePublisher;

        public OrdersController(IRepository<Order> repos, IServiceGateway<Product> gateway, IMessagePublisher publisher)
        {
            repository = repos;
            productServiceGateway = gateway;
            messagePublisher = publisher;
        }

        // GET: api/orders
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return repository.GetAll();
        }

        // GET api/products/5
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get(int id)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/orders
        [HttpPost]
        public IActionResult Post([FromBody]Order order)
        {

            if (order == null)
            {
                return BadRequest();
            }

            // Call product service to get the product ordered




            if (checkStock(order))

            {

                try
                {
                    // Publish OrderStatusChangedMessage. If this operation
                    // fails, the order will not be created

                    messagePublisher.PublishOrderStatusChangedMessage(order.Product, "orderCompleted");



                    // Create order.
                    order.Status = Order.OrderStatus.completed;
                    var newOrder = repository.Add(order);
                    return CreatedAtRoute("GetOrder", new { id = newOrder.Id }, newOrder);
                }
                catch
                {
                    order.Status = Order.OrderStatus.cancelled;
                    return StatusCode(500, "An error happened. Try again.");
                }
            }
            else
            {
                // If the order could not be created, "return no content".
                order.Status = Order.OrderStatus.cancelled;
                return StatusCode(500, "Not enough items in stock.");
            }
        }

        public bool checkStock(Order order)
        {

            for (int i = 0; i < order.Product.Count; i++)
            {
                var orderedProduct = productServiceGateway.Get(order.Product[i].ProductId);
                if (order.Product[i].Quantity >= orderedProduct.ItemsInStock - orderedProduct.ItemsReserved)
                {
                    return false;
                }
            }
            return true;


        }
        
    }
}
                

            


        
    
