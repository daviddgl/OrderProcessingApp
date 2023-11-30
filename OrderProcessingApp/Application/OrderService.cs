using OrderProcessingApp.Core;

namespace OrderProcessingApp.Application
{
    public class OrderService : IOrderService
    {
        private readonly IOrderProcessor _orderProcessor;

        public OrderService(IOrderProcessor orderProcessor)
        {
            _orderProcessor = orderProcessor;
        }

        public void CreateOrder(Order order)
        {
            _orderProcessor.ProcessOrder(order);
        }
    }
}
