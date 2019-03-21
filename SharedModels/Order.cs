using System;
using System.Collections.Generic;
namespace SharedModels
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public List<ProductOrder> Product { get; set; }
        public OrderStatus Status { get; set; }

        public enum OrderStatus
        {
            cancelled,
            completed,
            shipped,
            paid
        }
    }
}
