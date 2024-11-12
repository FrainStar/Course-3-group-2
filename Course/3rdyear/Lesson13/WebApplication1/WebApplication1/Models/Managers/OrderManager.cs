using WebApplication1.Models.Interfaces;
using WebApplication1.Models.Models;

namespace WebApplication1.Models.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly DatabaseContext _databaseContext;

        public OrderManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void CreateOrder(OrderModel order)
        {
            _databaseContext.Orders.Add(order);
            _databaseContext.SaveChanges();
        }

        public List<OrderModel> GetAllOrders()
        {
            return _databaseContext.Orders.ToList();
        }

        public string UpdateOrder(int id, OrderModel order)
        {
            OrderModel? oldOrder = _databaseContext.Orders.FirstOrDefault(o => o.Id == id);

            if (oldOrder != null)
            {
                oldOrder.UserId = order.UserId;
                oldOrder.Products = order.Products;
                _databaseContext.SaveChanges();
                return "Order updated";
            }
            
            return "Order not found";
        }
    }
}

