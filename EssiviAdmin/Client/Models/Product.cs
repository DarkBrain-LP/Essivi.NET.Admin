namespace EssiviAdmin.Client.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Essivi-";
        public double VolumeLitter { get; set; }
        public double Price { get; set; }
        public int Number { get; set; }
        public string CategoryName { get; set; } // is a subcategory
    }
}
