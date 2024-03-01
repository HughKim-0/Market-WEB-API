using Market_API.Models;

namespace Market_API.Interface
{
    public interface ICustomerRepository
    {
        bool CustomerExists(int Id);
        bool CustomerExists(string name);
        bool Save();
        bool CreateCustomer(Customer customer);
        ICollection<Customer> GetCustomers();
        Customer GetCustomer(int Id);
        Customer GetCustomer(string name);
        Customer GetCustomerByPhone(int phone);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);

    }
}
