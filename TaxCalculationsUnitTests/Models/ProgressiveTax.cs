namespace TaxCalculations.API.Tests.Models;

public partial class ProgressiveTax
{
    public int Id { get; set; }

    public int? Rate { get; set; }

    public double? FromAmount { get; set; }

    public double? ToAmount { get; set; }
}