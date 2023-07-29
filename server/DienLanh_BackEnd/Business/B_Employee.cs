using Microsoft.EntityFrameworkCore;
using WebAPI_JWT_NET6_Base.Models;
using WebAPI_JWT_NET6_Base.Services;

namespace WebAPI_JWT_NET6_Base.Business
{
    public class B_Employee : S_Employee
    {
        readonly DatabaseContext _dbContext = new();

        public B_Employee(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                return _dbContext.Employees!.ToList();
            }
            catch
            {
                return new List<Employee>();
            }
        }

        public Employee GetEmployeeDetails(string id)
        {
            try
            {
                Employee employee = _dbContext.Employees!.Find(id)!;

                return employee;

            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                _dbContext.Employees!.Add(employee);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                _dbContext.Entry(employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteEmployee(string id)
        {
            bool result = false;
            try
            {
                Employee employee = _dbContext.Employees!.Find(id)!;

                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    _dbContext.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch
            {
                return false;
            }

        }

        /*public bool CheckEmployee(string id)
        {
            try
            {
                if (_dbContext.Employees!.Any(employee => employee.EmployeeID == id))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }*/


    }
}
