using System;
using System.Collections.Generic;
<<<<<<< HEAD

=======
>>>>>>> ba8273192dd59aaa1d8ee793b32795b2872af172
namespace SharedModels
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
<<<<<<< HEAD
=======
        public List<ProductOrder> ProductsOrdered { get; set; }
        public int Quantity { get; set; }
>>>>>>> ba8273192dd59aaa1d8ee793b32795b2872af172
        public OrderStatus Status { get; set; }
        public List<Product> Products { get; set; }
        public enum OrderStatus
        {
            cancelled,
            completed,
            shipped,
            paid
        }
    }
}
