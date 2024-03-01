namespace Market_API.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }
        public int LocationPhone { get; set; }
        public ICollection<ProductLocation> ProductLocations {  get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
