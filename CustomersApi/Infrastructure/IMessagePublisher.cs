using System;
namespace Customer.Infrastructure
{
    public interface IMessagePublisher
    {
        void PublishOrderStatusChangedMessage(int productId, int quantity, string topic);
    }
}
