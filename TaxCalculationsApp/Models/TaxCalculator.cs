namespace TaxCalculationsApp.Models;

public class TaxCalculatorResult
{
    public int Id { get; set; }

    public string PostalCode { get; set; }

    public double? EnteredAmount { get; set; }

    public double? CalculatedAmount { get; set; }

    public DateTime? Date { get; set; }
}