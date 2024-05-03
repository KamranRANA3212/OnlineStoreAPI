using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Interfaces
{
    public interface IOrder
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}
