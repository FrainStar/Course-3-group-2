using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Interfaces;
using WebApplication1.Models.Models;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager userManager)
        {
            _orderManager = userManager;
        }
        
        
        [HttpPost("/api/orders/create")]
        public IActionResult CreateOrder([FromBody] OrderModel user)
        {
            _orderManager.CreateOrder(user);
            return Ok("Order created");
        }

        [HttpGet("/api/orders/")]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderManager.GetAllOrders());
        }

        [HttpPost("/api/orders/update/{orderId}")]
        public IActionResult UpdateOrder(int orderId, [FromBody] OrderModel user)
        {
            string result = _orderManager.UpdateOrder(orderId, user);

            if (result == "Order updated")
            {
                return Ok("Order updated");
            }
            
            return NotFound("Order not found");
        }
        
    }
}