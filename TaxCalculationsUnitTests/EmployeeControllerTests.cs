using Moq;
using TaxCalculations.API.Tests.Interfaces;

namespace TaxCalculations.API.Tests
{
    public class EmployeesControllerTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepo;
        private readonly TaxCalculationsAPI.Controllers.EmployeeController _controller;

        public EmployeesControllerTests()
        {
        }
    }
}