namespace EssiviAdmin.Client.Models
{
    public class SubCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }
        public string Description
        {
            get => Category + "-" + Name;
        }
    }
}
