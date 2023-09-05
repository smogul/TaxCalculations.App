using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaxCalculations.Apps.Data;
using TaxCalculations.Apps.Models;
using TaxCalculationsApp.Data;
using TaxCalculationsApp.Models;

namespace TaxCalculationsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> _logger)
        {
            logger = _logger;
            _logger.LogInformation("created PostalCodeRestRequest");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SalaryDetails(string postalCode, double annualSalary)
        {
            var employeeRestRequest = new EmployeeRestRequest();
            var calculatorRestRequest = new TaxCalculatorRestRequest();
            var postalCodeRestRequest = new PostalCodeRestRequest();
            var individualTaxCalculator = new IndividualTaxCalculator();

            try
            {
                var getPostalCodes = postalCodeRestRequest.RetrieveAllPostalCodes();
                var calculatedTaxOutcome = 0.0;

                for (int i = 0; i < getPostalCodes.Count; i++)
                {
                    var postalC = getPostalCodes[i];
                    if (postalC.PostalCode1.Equals(postalCode) && postalC.TaxCalculationType.Equals("Progressive"))
                    {
                        calculatedTaxOutcome = individualTaxCalculator.CalculatedProgressiveTax(annualSalary);
                        break;
                    }
                    if (postalC.PostalCode1.Equals(postalCode) && postalC.TaxCalculationType.Equals("Flat Value"))
                    {
                        calculatedTaxOutcome = individualTaxCalculator.CalculatedFlatValue(annualSalary);
                        break;
                    }
                    if (postalC.PostalCode1.Equals(postalCode) && postalC.TaxCalculationType.Equals("Flat rate"))
                    {
                        calculatedTaxOutcome = individualTaxCalculator.CalculatedFlatRate(annualSalary);
                        break;
                    }
                }

                if (calculatedTaxOutcome > 0.0)
                {
                    DateTime myDateTime = DateTime.Now;
                    string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    var taxObj = new TaxCalculatorResult
                    {
                        CalculatedAmount = calculatedTaxOutcome,
                        EnteredAmount = annualSalary,
                        PostalCode = postalCode,
                        Date = Convert.ToDateTime(sqlFormattedDate),
                    };

                    var insertResults = calculatorRestRequest.InsertNewTaxCalculator(taxObj);
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

            //var ddd = individualTaxCalculator.CalculatedFlatRate(95000.00);
            //var aaa = individualTaxCalculator.CalculatedFlatValue(95000.00);
            var dddf = individualTaxCalculator.CalculatedProgressiveTax(9500.00);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}