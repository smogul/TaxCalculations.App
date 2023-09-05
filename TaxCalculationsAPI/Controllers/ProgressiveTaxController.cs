using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxCalculationsAPI.Models;

namespace TaxCalculationsAPI.Controllers
{
    /// <summary>
    /// Progressive Tax Controller
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProgressiveTaxController : ControllerBase
    {
        private Db_TaxCalculationContext _progressiveTaxContext;
        private ILogger<ProgressiveTaxController> logger;

        public ProgressiveTaxController(Db_TaxCalculationContext progressiveTaContext, ILogger<ProgressiveTaxController> _logger)
        {
            _progressiveTaxContext = progressiveTaContext;
            logger = _logger;
            _logger.LogInformation("created EmpController");
        }

        /// <summary>
        /// Get All Progressive Taxes records
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProgressiveTaxes()
        {
            try
            {
                var progressiveTaxes = await _progressiveTaxContext.ProgressiveTaxes.ToListAsync();

                if (progressiveTaxes != null)
                    return Ok(progressiveTaxes);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
                throw;
            }
            finally
            {
                //dispose nlog once complete
                NLog.LogManager.Shutdown();
            }

            return Ok(null);
        }

        /// <summary>
        /// Get Progressive Record By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public ProgressiveTax GetProgressiveById(int id)
        {
            try
            {
                var progressiveTax = _progressiveTaxContext.ProgressiveTaxes.Where(x => x.Id == id).FirstOrDefault();
                if (progressiveTax != null)
                    return progressiveTax;
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

            return new ProgressiveTax();
        }

        /// <summary>
        /// Add Progressive Tax record
        /// </summary>
        /// <param name="progressiveTax"></param>
        /// <returns></returns>
        [HttpPut]
        public bool AddProgressiveTax(ProgressiveTax progressiveTax)
        {
            try
            {
                var addPostal = _progressiveTaxContext.ProgressiveTaxes.Add(progressiveTax);
                if (addPostal != null)
                    _progressiveTaxContext.SaveChanges();
                return true;
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

            return false;
        }

        /// <summary>
        /// Update Progressive Tax record
        /// </summary>
        /// <param name="progressiveTax"></param>
        /// <returns></returns>
        [HttpPut]
        public bool UpdateProgressiveTax(ProgressiveTax progressiveTax)
        {
            try
            {
                var updateProgressive = _progressiveTaxContext.ProgressiveTaxes.Update(progressiveTax);
                if (updateProgressive != null)
                    _progressiveTaxContext.SaveChanges();
                return true;
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
            return false;
        }

        /// <summary>
        /// Remove Progressive record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public bool RemoveProgressiveTax(int id)
        {
            try
            {
                var removeProgressive = _progressiveTaxContext.ProgressiveTaxes.Where(x => x.Id == id).FirstOrDefault();

                if (removeProgressive != null)
                    _progressiveTaxContext.ProgressiveTaxes.Remove(removeProgressive);
                _progressiveTaxContext.SaveChanges();

                return true;
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

            return false;
        }
    }
}