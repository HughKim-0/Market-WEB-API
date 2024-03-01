namespace Market_API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
        public int Qauantity { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductLocation> ProductLocations { get; set; }
        public ICollection<ProductPayment> ProductPayments { get; set; }

    }
}
