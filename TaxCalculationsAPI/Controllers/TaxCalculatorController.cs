using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxCalculationsAPI.Models;

namespace TaxCalculations.API.Controllers
{
    /// <summary>
    /// Tax Calculator Controller
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaxCalculatorController : ControllerBase
    { /// <summary>
      /// loggging and dbcontext
      /// </summary>
        private Db_TaxCalculationContext _taxCalculationsContext;

        private ILogger<TaxCalculatorController> logger;

        public TaxCalculatorController(Db_TaxCalculationContext taxCalculatorResultContext, ILogger<TaxCalculatorController> _logger)
        {
            _taxCalculationsContext = taxCalculatorResultContext;
            logger = _logger;
            _logger.LogInformation("created TaxCalculatorController");
        }

        /// <summary>
        /// Get All TaxCalculatorResults records
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetAllTaxCalculators()
        {
            try
            {
                var TaxCalculatorResults = await _taxCalculationsContext.TaxCalculatorResults.ToListAsync();
                if (TaxCalculatorResults != null)
                {
                    return Ok(TaxCalculatorResults);
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
            return NotFound();
        }

        /// <summary>
        /// Get TaxCalculatorResult record By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public TaxCalculatorResult GetTaxCalculatorById(int id)
        {
            try
            {
                var taxCalculatorResult = _taxCalculationsContext.TaxCalculatorResults.Where(x => x.Id == id).FirstOrDefault();
                if (taxCalculatorResult != null)
                {
                    return taxCalculatorResult;
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

            return new TaxCalculatorResult();
        }

        /// <summary>
        /// Add TaxCalculatorResult record
        /// </summary>
        /// <param name="taxCalculatorResult"></param>
        /// <returns></returns>
        [HttpPut()]
        public string AddTaxCalculator(TaxCalculatorResult taxCalculator)
        {
            var response = "";
            try
            {
                var addtaxCalculatorResult = _taxCalculationsContext.TaxCalculatorResults.Add(taxCalculator);
                if (addtaxCalculatorResult != null)
                {
                    _taxCalculationsContext.SaveChanges();
                    response = string.Format("Successfully a new taxCalculatorResult");
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
                response = string.Format("Could not insert {0}. Error returned: {1}. Please check logs for more details", taxCalculator.Id, exception.Message);
            }
            finally
            {
                //dispose nlog once complete
                NLog.LogManager.Shutdown();
            }

            return response;
        }

        /// <summary>
        /// Update TaxCalculatorResult record
        /// </summary>
        /// <param name="taxCalculatorResult"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public string UpdateTaxCalculator(int? id, TaxCalculatorResult taxCalculatorResult)
        {
            var response = "";
            try
            {
                var index = _taxCalculationsContext.TaxCalculatorResults.Where(c => c.Id == id);

                if (index != null)
                {
                    _taxCalculationsContext.TaxCalculatorResults.Update(taxCalculatorResult);
                    _taxCalculationsContext.SaveChanges(true);
                    response = string.Format("Successfully updated {0} taxCalculatorResult", taxCalculatorResult.Id);
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
                response = string.Format("Could not insert {0}. Error returned: {1}. Please check logs for more details", taxCalculatorResult.Id, exception.Message);
            }
            finally
            {
                //dispose nlog once complete
                NLog.LogManager.Shutdown();
            }
            return response;
        }

        /// <summary>
        /// Remove TaxCalculatorResult record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public string RemoveTaxCalculator(int id)
        {
            var response = "";
            var taxCalculatorResult = new TaxCalculatorResult();
            try
            {
                taxCalculatorResult = _taxCalculationsContext.TaxCalculatorResults.Where(x => x.Id == id).FirstOrDefault();

                if (taxCalculatorResult != null)
                {
                    _taxCalculationsContext.TaxCalculatorResults.Remove(taxCalculatorResult);
                    _taxCalculationsContext.SaveChanges();

                    response = string.Format("Successfully removed {0} {1} as new taxCalculatorResult", taxCalculatorResult.Id);
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
                response = string.Format("Could not insert {0}. Error returned: {1}. Please check logs for more details", taxCalculatorResult.Id, exception.Message);
            }
            finally
            {
                //dispose nlog once complete
                NLog.LogManager.Shutdown();
            }

            return response;
        }
    }
}