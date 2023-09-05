using TaxCalculations.API.Tests.Interfaces;
using TaxCalculations.API.Tests.Models;

namespace TaxCalculations.API.Tests.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmplyees()
        {
            return MockData.MockData.EmployeesMockData();
        }

        public Employee GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}