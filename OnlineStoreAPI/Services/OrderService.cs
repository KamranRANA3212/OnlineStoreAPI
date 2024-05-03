using Microsoft.EntityFrameworkCore;
using OnlineStoreAPI.Data;
using OnlineStoreAPI.Interfaces;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Services
{
    public class OrderService : IOrder
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context) 
        { 
           _context = context;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            decimal totalAmount = await CalculateTotalAmount(order.OrderDetails);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            foreach (var orderDetail in order.OrderDetails)
            {
                var item = await _context.Items.FindAsync(orderDetail.ItemId);
                if (item != null)
                {
                    item.Quantity -= orderDetail.Quantity; 
                    _context.Entry(item).State = EntityState.Modified;
                }
            }

            await _context.SaveChangesAsync();
            return order;
        }
        private async Task<decimal> CalculateTotalAmount(IEnumerable<OrderDetail> orderDetails)
        {
            decimal totalAmount = 0;
            foreach (var orderDetail in orderDetails)
            {
                var item = await _context.Items.FindAsync(orderDetail.ItemId);
                if (item != null)
                {
                    totalAmount += orderDetail.Quantity * item.ItemCost;
                }
            }
            return totalAmount;
        }
    }
}
