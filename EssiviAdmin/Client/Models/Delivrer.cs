namespace EssiviAdmin.Client.Models
{
    public class Delivrer
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }        
        public string Quarter { get; set; }
        public string Phone { get; set; }

        public string? Picture { get; set; }
        public DateTime? HireDate { get; set; } = DateTime.Now;

        public string CompleteName
        {
            get => $"{Id}: {Name} {FirstName}";
        }
    }
}
