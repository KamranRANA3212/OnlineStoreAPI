using Microsoft.AspNetCore.Mvc;
using OnlineStoreAPI.Interfaces;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;
        public OrderController(IOrder order)
        {
            _order = order;
        }
        [HttpPost("CreateOrder")]
        public async Task<ActionResult> AddItem([FromBody] Order model)
        {
          await _order.CreateOrderAsync(model);
            return Ok(model.OrderId);
        }
    }
}
