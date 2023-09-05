namespace TaxCalculationsApp.Models;

public class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Department { get; set; }

    public string Position { get; set; }

    public string StartDate { get; set; }

    public double? SalaryAmount { get; set; }
}