using Market_API.Models;

namespace Market_API.Interface
{
    public interface IPaymentRepository
    {
        bool PaymentExists(int Id);
        bool Save();
        bool CreatePayment(Payment payment);
        ICollection<Payment> GetPayments();
        Payment GetPayment(int Id);
        bool UpdatePayment(Payment payment);
        bool DeletePayment(Payment payment);
    }
}
