using TaxCalculations.API.Tests.Models;

namespace TaxCalculations.API.Tests.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmplyees();

        Employee GetEmployeeById(int id);

        bool AddEmployee(Employee employee);

        bool UpdateEmployee(Employee employee);

        bool DeleteEmployee(int id);
    }
}