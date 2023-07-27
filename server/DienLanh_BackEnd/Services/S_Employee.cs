using WebAPI_JWT_NET6_Base.Models;

namespace WebAPI_JWT_NET6_Base.Services
{
    public interface S_Employee
    {
        public List<Employee> GetEmployeeDetails();
        public Employee GetEmployeeDetails(int id);
        public bool AddEmployee(Employee employee);
        public bool UpdateEmployee(Employee employee);
        public bool DeleteEmployee(int id);
        public bool CheckEmployee(int id);
    }
}
