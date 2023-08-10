using PasteryShop.Models;

namespace PasteryShop.Services
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
