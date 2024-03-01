namespace Market_API.Models
{
    public class ProductLocation
    {
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public Product Product { get; set; }
        public Location Location { get; set; }
        public int ProductLocationQuantity { get; set; }

    }
}
