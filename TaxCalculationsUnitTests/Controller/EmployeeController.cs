using TaxCalculations.API.Tests.Interfaces;

namespace TaxCalculations.API.Tests.Controller
{
    public class EmployeeController
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
    }
}