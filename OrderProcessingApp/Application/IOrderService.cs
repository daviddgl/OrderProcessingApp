using OrderProcessingApp.Core;

namespace OrderProcessingApp.Application
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
    }
}
