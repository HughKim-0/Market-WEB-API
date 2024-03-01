namespace Market_API.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public Location LocationId { get; set; }
        public Customer CutstomerId { get; set; }
        public ICollection<ProductPayment> ProductPayments { get; set; }

    }
}
