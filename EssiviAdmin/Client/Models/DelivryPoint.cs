namespace EssiviAdmin.Client.Models
{
    public class DelivryPoint
    {
        public int Id { get; set; }
        public string Quarter { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string StringValue
        {
            get => $"{Quarter} - ({Latitude}, {Longitude}";
        }
    }
}
