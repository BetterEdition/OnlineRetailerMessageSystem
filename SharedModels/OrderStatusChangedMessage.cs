using System.Collections.Generic;

namespace SharedModels
{
    public class OrderStatusChangedMessage
    {
        public List<ProductOrder> orderLine;
    }
}
