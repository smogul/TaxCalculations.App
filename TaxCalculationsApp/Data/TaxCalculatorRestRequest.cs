using Newtonsoft.Json;
using RestSharp;
using TaxCalculationsApp.Models;

namespace TaxCalculations.Apps.Data
{
    /// <summary>
    /// TaxCalculator Rest Request class.
    /// </summary>
    public class TaxCalculatorRestRequest
    {
        private RestClient client = new RestClient("https://localhost:7054/api/TaxCalculator/");
        private ILogger<TaxCalculatorRestRequest> logger;

        public TaxCalculatorRestRequest(ILogger<TaxCalculatorRestRequest> _logger)
        {
            logger = _logger;
            _logger.LogInformation("created TaxCalculatorRestRequest");
        }

        public TaxCalculatorRestRequest()
        {
        }

        /// <summary>
        /// Retrieve list of All TaxCalculators
        /// </summary>
        /// <returns></returns>
        public List<TaxCalculatorResult> RetrieveAllTaxCalculators()
        {
            var TaxCalculators = new List<TaxCalculatorResult>();
            try
            {
                var request = new RestRequest("GetAllTaxCalculators", Method.Get);
                var result = client.Execute<List<TaxCalculatorResult>>(request);
                if (result != null)
                {
                    TaxCalculators = result.Data;
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

            return TaxCalculators;
        }

        /// <summary>
        /// Get Single TaxCalculator
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TaxCalculatorResult GetSingleTaxCalculator(int id)
        {
            var TaxCalculator = new TaxCalculatorResult();
            try
            {
                var request = new RestRequest("GetTaxCalculatorById/" + id, Method.Get);
                var result = client.Execute(request);
                if (result != null)
                {
                    TaxCalculator = JsonConvert.DeserializeObject<TaxCalculatorResult>(result.Content);
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
            return TaxCalculator;
        }

        /// <summary>
        /// Insert New TaxCalculator
        /// </summary>
        /// <param name="TaxCalculator"></param>
        /// <returns></returns>
        public string InsertNewTaxCalculator(TaxCalculatorResult TaxCalculator)
        {
            try
            {
                var request = new RestRequest("AddTaxCalculator", Method.Put);
                request.AddBody(TaxCalculator);
                var result = client.Execute(request);
                if (result.IsSuccessStatusCode)
                {
                    return string.Format("Successfully inserted {0}  TaxCalculator", TaxCalculator.Id);
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

            return "not added";
        }

        /// <summary>
        /// Edit TaxCalculator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="TaxCalculator"></param>
        /// <returns></returns>
        public string EditTaxCalculator(int id, TaxCalculatorResult TaxCalculator)
        {
            try
            {
                var request = new RestRequest("UpdateTaxCalculator/" + id, Method.Put);
                request.AddBody(TaxCalculator);
                var result = client.Execute(request);
                if (result.IsSuccessStatusCode)
                {
                    return string.Format("Successfully inserted {0}  TaxCalculator", TaxCalculator.Id);
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

            return "not added";
        }

        /// <summary>
        /// Delete TaxCalculator
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteTaxCalculator(int id)
        {
            var response = "";
            try
            {
                var request = new RestRequest("RemoveTaxCalculator/" + id, Method.Delete);
                var result = client.Execute(request);
                if (result.IsSuccessful)
                {
                    response = result.Content;
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
                response = string.Format("Could not delete record Id: {0}. Error returned: {1}. Please check logs for more details", id, exception.Message);
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