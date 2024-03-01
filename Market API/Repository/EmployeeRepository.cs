using Market_API.Data;
using Market_API.Interface;
using Market_API.Models;

namespace Market_API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //Date Context//
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        //Check the Employee Exists//
        public bool EmployeeExists(int Id)
        {
            return _context.Employee.Any(o => o.EmployeeId == Id);
        }
        public bool EmployeeExists(string name)
        {
            return _context.Employee.Any(o => o.EmployeeName == name);
        }


        //Save//
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //Create Method//
        public bool CreateEmployee(Employee employee)
        {
            _context.Add(employee);
            return Save();
        }

        //Read Method//
        public ICollection<Employee> GetEmployees()
        {
            return _context.Employee.ToList();
        }
        public Employee GetEmployee(int Id)
        {
            return _context.Employee.Where(c => c.EmployeeId == Id).FirstOrDefault();
        }
        public Employee GetEmployee(string name)
        {
            return _context.Employee.Where(c => c.EmployeeName == name).FirstOrDefault();
        }
        public Employee GetEmployeeByPhone(int phone)
        {
            return _context.Employee.Where(c => c.EmployeePhone == phone).FirstOrDefault();
        }

        //Update Method//
        public bool UpdateEmployee(Employee emplopyee)
        {
            _context.Update(emplopyee);
            return Save();
        }

        //Delete Method//
        public bool DeleteEmployee(Employee emplopyee)
        {
            _context.Remove(emplopyee);
            return Save();
        }
    }
}
