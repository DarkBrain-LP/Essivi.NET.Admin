namespace EssiviAdmin.Client.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName {get; set;}
        public Customer Customer { get; set; }
        public DelivryPoint DeliveryPoint { get; set;}
        public List<OrderItem> Products { get; set; }
        public int Quantity 
        { 
            get => Products.Sum(p => p.Quantity);
        }

        public int Price
        {
            get => Products.Sum(p => ((int)p.Product.Price) * p.Quantity);
        }

        public bool CanBeUpdated { get; set; }
        public DateTime DeliverBefore { get; set; }
    }
}
