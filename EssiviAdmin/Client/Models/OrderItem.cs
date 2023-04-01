namespace EssiviAdmin.Client.Models
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        
        public int Price
        { 
            get => ((int)Product.Price) * Quantity;
        }
    }
}
