using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxCalculationsAPI.Models;

namespace TaxCalculationsAPI.Controllers
{
    /// <summary>
    /// Postal Code Controller
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostalCodeController : ControllerBase
    {
        private Db_TaxCalculationContext _postalCodeContext;
        private ILogger<PostalCodeController> logger;

        public PostalCodeController(Db_TaxCalculationContext postalCodeContext, ILogger<PostalCodeController> _logger)
        {
            _postalCodeContext = postalCodeContext;
            logger = _logger;
            _logger.LogInformation("created PostalCodeController");
        }

        /// <summary>
        /// Get All Postal Code records
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPostalCodes()
        {
            try
            {
                var postalCodes = await _postalCodeContext.PostalCodes.ToListAsync();

                if (postalCodes != null)
                    return Ok(postalCodes);
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
        /// Get Postal Code Record By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public PostalCode GetPostalCodeById(int id)
        {
            try
            {
                var postalCode = _postalCodeContext.PostalCodes.Where(x => x.Id == id).FirstOrDefault();
                if (postalCode != null)
                    return postalCode;
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

            return new PostalCode();
        }

        /// <summary>
        /// Add Postal Code record
        /// </summary>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        [HttpPut]
        public bool AddPostalCode(PostalCode postalCode)
        {
            try
            {
                var addPostal = _postalCodeContext.PostalCodes.Add(postalCode);
                if (addPostal != null)
                    _postalCodeContext.SaveChanges();
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
        /// Update Postal Code record
        /// </summary>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        [HttpPut]
        public bool UpdatePostalCode(PostalCode postalCode)
        {
            try
            {
                var updatePostal = _postalCodeContext.PostalCodes.Update(postalCode);
                if (updatePostal != null)
                    _postalCodeContext.SaveChanges();
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
        /// Remove Postal Code record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public bool RemovePostalCode(int id)
        {
            try
            {
                var removePostal = _postalCodeContext.PostalCodes.Where(x => x.Id == id).FirstOrDefault();

                if (removePostal != null)
                    _postalCodeContext.PostalCodes.Remove(removePostal);
                _postalCodeContext.SaveChanges();

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