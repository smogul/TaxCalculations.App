using Newtonsoft.Json;
using RestSharp;
using TaxCalculationsApp.Models;

namespace TaxCalculationsApp.Data
{
    /// <summary>
    /// ProgressiveTax Rest Request class.
    /// </summary>
    public class ProgressiveTaxRestRequest
    {
        private RestClient client = new RestClient("https://localhost:7054/api/ProgressiveTax/");
        private ILogger<ProgressiveTaxRestRequest> logger;

        public ProgressiveTaxRestRequest(ILogger<ProgressiveTaxRestRequest> _logger)
        {
            logger = _logger;
            _logger.LogInformation("created EmpController");
        }

        public ProgressiveTaxRestRequest()
        {
        }

        /// <summary>
        /// Retrieve list of All ProgressiveTaxs
        /// </summary>
        /// <returns></returns>
        public List<ProgressiveTax> RetrieveAllProgressiveTaxs()
        {
            var ProgressiveTaxs = new List<ProgressiveTax>();
            try
            {
                var request = new RestRequest("GetAllProgressiveTaxes", Method.Get);
                var result = client.Execute<List<ProgressiveTax>>(request);
                if (result != null)
                {
                    ProgressiveTaxs = result.Data;
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

            return ProgressiveTaxs;
        }

        /// <summary>
        /// Get Single ProgressiveTax
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProgressiveTax GetSingleProgressiveTax(int id)
        {
            var ProgressiveTax = new ProgressiveTax();
            try
            {
                var request = new RestRequest("GetProgressiveTaxById/" + id, Method.Get);
                var result = client.Execute(request);
                if (result != null)
                {
                    ProgressiveTax = JsonConvert.DeserializeObject<ProgressiveTax>(result.Content);
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
            return ProgressiveTax;
        }

        /// <summary>
        /// Insert New Empolyee
        /// </summary>
        /// <param name="ProgressiveTax"></param>
        /// <returns></returns>
        public string InsertNewEmpolyee(ProgressiveTax progressiveTax)
        {
            try
            {
                var request = new RestRequest("AddProgressiveTax", Method.Put);
                request.AddBody(progressiveTax);
                var result = client.Execute(request);
                if (result.IsSuccessStatusCode)
                {
                    return string.Format("Successfully inserted {0} as new ProgressiveTax", progressiveTax.Id);
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
        /// Edit Empolyee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ProgressiveTax"></param>
        /// <returns></returns>
        public string EditEmpolyee(int id, ProgressiveTax progressiveTax)
        {
            try
            {
                var request = new RestRequest("UpdateProgressiveTax/" + id, Method.Put);
                request.AddBody(progressiveTax);
                var result = client.Execute(request);
                if (result.IsSuccessStatusCode)
                {
                    return string.Format("Successfully inserted {0}  as new ProgressiveTax", progressiveTax.Id);
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
        /// Delete ProgressiveTax
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteProgressiveTax(int id)
        {
            var response = "";
            try
            {
                var request = new RestRequest("RemoveProgressiveTax/" + id, Method.Delete);
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