using Market_API.Models;

namespace Market_API.Interface
{
    public interface IEmployeeRepository
    {
        bool EmployeeExists(int Id);
        bool EmployeeExists(string name);
        bool Save();
        bool CreateEmployee(Employee employee);
        ICollection<Employee> GetEmployees();
        Employee GetEmployee(int Id);
        Employee GetEmployee(string name);
        Employee GetEmployeeByPhone(int phone);
        bool UpdateEmployee(Employee emplopyee);
        bool DeleteEmployee(Employee emplopyee);
    }
}
