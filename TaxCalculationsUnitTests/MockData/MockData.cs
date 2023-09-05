using TaxCalculations.API.Tests.Models;

namespace TaxCalculations.API.Tests.MockData
{
    public static class MockData
    {
        public static Employee EmployeeMockData()
        {
            return new Employee
            {
                Id = 1,
                Department = "TestDept",
                FirstName = "TestName",
                LastName = "TestLName",
                Position = "TestPosision",
                SalaryAmount = 95000,
                StartDate = "2022/03/20"
            };
        }

        public static List<Employee> EmployeesMockData()
        {
            return new List<Employee> {
               new Employee
               {
                Id = 1,
                Department = "TestDept1",
                FirstName = "TestName1",
                LastName = "TestLName1",
                Position = "TestPosision1",
                SalaryAmount = 95000,
                StartDate = "2022/03/20"
               },
               new Employee
               {
                Id = 2,
                Department = "TestDept2",
                FirstName = "TestName2",
                LastName = "TestLName2",
                Position = "TestPosision2",
                SalaryAmount = 95000,
                StartDate = "2022/03/20"
               },new Employee
               {
                Id = 3,
                Department = "TestDept3",
                FirstName = "TestName3",
                LastName = "TestLName3",
                Position = "TestPosision3",
                SalaryAmount = 95000,
                StartDate = "2022/03/20"
               },
            };
        }
    }
}