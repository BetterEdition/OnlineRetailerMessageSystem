using System;
using SharedModels;

namespace CustomersApi.Infrastructure
{
    public interface IServiceGateway<T>
    {
        T Get(int id);
    }
}
