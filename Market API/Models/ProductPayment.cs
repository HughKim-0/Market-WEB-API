namespace Market_API.Models
{
    public class ProductPayment
    {
        public int ProductId { get; set; }
        public int PaymentId { get; set; }
        public Product Product { get; set; }
        public Payment Payment { get; set; }
    }
}
