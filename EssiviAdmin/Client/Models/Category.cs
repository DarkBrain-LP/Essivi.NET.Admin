namespace EssiviAdmin.Client.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<SubCategory> subCategories { get; set; }
    }
}
