using TaxCalculationsApp.Data;

namespace TaxCalculations.Apps.Models
{
    public class IndividualTaxCalculator
    {
        private ProgressiveTaxRestRequest progressiveTaxinfo = new ProgressiveTaxRestRequest();
        private ILogger<IndividualTaxCalculator> logger;

        public IndividualTaxCalculator(ILogger<IndividualTaxCalculator> _logger)
        {
            logger = _logger;
            _logger.LogInformation("created EmployeeRestRequest");
        }

        public IndividualTaxCalculator()
        {
        }

        public double CalculatedProgressiveTax(double annualSalary)
        {
            var calculatorResults = 0.0;
            try
            {
                var progrssTaxList = progressiveTaxinfo.RetrieveAllProgressiveTaxs();
                for (int i = 0; i < progrssTaxList.Count; i++)
                {
                    var taxBracket = progrssTaxList[i];
                    int fromAmount = int.Parse(taxBracket.FromAmount.ToString());
                    int toAmount = int.Parse(taxBracket.ToAmount.ToString());
                    int salary = int.Parse(annualSalary.ToString());

                    if (Enumerable.Range(fromAmount, toAmount).Contains(salary))
                    {
                        double ratePercentage = taxBracket.Rate / 100d;
                        calculatorResults = (annualSalary - (annualSalary * ratePercentage));
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
            }
            finally
            {
                //dispose nlog once complete
                NLog.LogManager.Shutdown();
            }

            return calculatorResults;
        }

        public double CalculatedFlatRate(double salaryAmount)
        {
            var flatRate = 0.175;
            var overallFlatSalaryCalculated = 0.0;
            try
            {
                overallFlatSalaryCalculated = ((salaryAmount) - (salaryAmount * flatRate));
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
            }
            finally
            {
                //dispose nlog once complete
                NLog.LogManager.Shutdown();
            }

            return overallFlatSalaryCalculated;
        }

        public double CalculatedFlatValue(double salaryAmount)
        {
            var flatValueTax = 0.05;
            var flatValueSalary = 200000;
            var overallFlatSalaryCalculated = 0.0;

            try
            {
                //check if flat value applies
                if (salaryAmount < flatValueSalary)
                {
                    overallFlatSalaryCalculated = ((salaryAmount) - (salaryAmount * flatValueTax));
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
            }
            finally
            {
                //dispose nlog once complete
                NLog.LogManager.Shutdown();
            }

            return overallFlatSalaryCalculated;
        }
    }

    public class TaxCalculatorResults
    {
        public string TaxPayerName { get; set; }
        public string TaxType { get; set; }
        public double? TaxAmount { get; set; }
        public double? AnnualSalaryBeforeTax { get; set; }
        public double? AnnualSalaryAfterTax { get; set; }
    }
}