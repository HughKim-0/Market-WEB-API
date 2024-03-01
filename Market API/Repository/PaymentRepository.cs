using Market_API.Data;
using Market_API.Interface;
using Market_API.Models;

namespace Market_API.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DataContext _context;

        public PaymentRepository(DataContext context)
        {
            _context = context;
        }

        //Check the Payment Exists//
        public bool PaymentExists(int Id)
        {
            return _context.Payment.Any(p => p.PaymentId == Id);
        }

        //Save//
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //Create Method//
        public bool CreatePayment(Payment payment)
        {
            _context.Add(payment);
            return Save();
        }

        //Read Method//
        public ICollection<Payment> GetPayments()
        {
            return _context.Payment.ToList();
        }
        public Payment GetPayment(int Id)
        {
            return _context.Payment.Where(p => p.PaymentId == Id).FirstOrDefault();
        }

        //Update Method//
        public bool UpdatePayment(Payment payment)
        {
            _context.Update(payment);
            return Save();
        }

        //Delete Method//
        public bool DeletePayment(Payment payment)
        {
            _context.Remove(payment);
            return Save();
        }
    }
}
