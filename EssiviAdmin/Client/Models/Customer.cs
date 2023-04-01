namespace EssiviAdmin.Client.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Quarter { get; set; }
        public string Phone { get; set; }
        public CustomerType? CustomerType { get; set; }
        public string Type { get; set; }
        public DelivryPoint HomeLocation { get; set; }
        public List<DelivryPoint> DelivryPoints { get; set; }

        public Delivrer Delivrer { get; set; }
        public string DelivrerName { get; set; }

        public string FullName
        { 
            get => $"{FirstName} {Name} - {Quarter} - {DelivrerName}";
        }
    }
}
