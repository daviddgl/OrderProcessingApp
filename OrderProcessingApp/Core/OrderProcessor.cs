namespace OrderProcessingApp.Core
{
    public class OrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            ValidateOrder(order);
        }

        public void ValidateOrder(Order order)
        {
            if (string.IsNullOrEmpty(order.CustomerName) || string.IsNullOrEmpty(order.ProductName))
                throw new ArgumentException("CustomerName and ProductName are required.");

            if (order.Quantity <= 0 || order.Price <= 0)
                throw new ArgumentException("Quantity and Price must be greater than zero.");

            // TODO: Do what it needs to do and probably save in DB
        }
    }
}
