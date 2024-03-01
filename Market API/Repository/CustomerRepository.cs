using Market_API.Data;
using Market_API.Interface;
using Market_API.Models;

namespace Market_API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        //Date Context//
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        //Check the Customer Exists//
        public bool CustomerExists(int Id)
        {
            return _context.Customer.Any(o => o.CustomerId == Id);
        }
        public bool CustomerExists(string name)
        {
            return _context.Customer.Any(o => o.CustomerName == name);
        }

        //Save//
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //Create Method//
        public bool CreateCustomer(Customer customer)
        {
            _context.Add(customer);
            return Save();
        }

        //Read Method//
        public ICollection<Customer> GetCustomers()
        {
            return _context.Customer.ToList();
        }
        public Customer GetCustomer(int Id)
        {
            return _context.Customer.Where(c => c.CustomerId == Id).FirstOrDefault();
        }
        public Customer GetCustomer(string name)
        {
            return _context.Customer.Where(c => c.CustomerName == name).FirstOrDefault();
        }
        public Customer GetCustomerByPhone(int phone)
        {
            return _context.Customer.Where(c => c.CustomerPhone == phone).FirstOrDefault();
        }

        //Update Method//
        public bool UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            return Save();
        }

        //Delete Method//
        public bool DeleteCustomer(Customer customer)
        {
            _context.Remove(customer);
            return Save();
        }
    }
}
