
using WebApplication1.Models.Models;

namespace WebApplication1.Models.Interfaces
{
    public interface IOrderManager
    {
        void CreateOrder(OrderModel order);
        List<OrderModel> GetAllOrders();
        string UpdateOrder(int id, OrderModel order);
    }
}

