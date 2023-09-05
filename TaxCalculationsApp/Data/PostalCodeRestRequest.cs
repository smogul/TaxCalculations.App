using Newtonsoft.Json;
using RestSharp;
using TaxCalculationsApp.Models;

namespace TaxCalculationsApp.Data
{
    /// <summary>
    /// PostalCode Rest Request class.
    /// </summary>
    public class PostalCodeRestRequest
    {
        private RestClient client = new RestClient("https://localhost:7054/api/PostalCode/");
        private ILogger<PostalCodeRestRequest> logger;

        public PostalCodeRestRequest(ILogger<PostalCodeRestRequest> _logger)
        {
            logger = _logger;
            _logger.LogInformation("created PostalCodeRestRequest");
        }

        public PostalCodeRestRequest()
        {
        }

        /// <summary>
        /// Retrieve list of All PostalCodes
        /// </summary>
        /// <returns></returns>
        public List<PostalCode> RetrieveAllPostalCodes()
        {
            var PostalCodes = new List<PostalCode>();
            try
            {
                var request = new RestRequest("GetAllPostalCodes", Method.Get);
                var result = client.Execute<List<PostalCode>>(request);
                if (result != null)
                {
                    PostalCodes = result.Data;
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

            return PostalCodes;
        }

        /// <summary>
        /// Get Single PostalCode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PostalCode GetSinglePostalCode(int id)
        {
            var PostalCode = new PostalCode();
            try
            {
                var request = new RestRequest("GetPostalCodeById/" + id, Method.Get);
                var result = client.Execute(request);
                if (result != null)
                {
                    PostalCode = JsonConvert.DeserializeObject<PostalCode>(result.Content);
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
            return PostalCode;
        }

        /// <summary>
        /// Insert New Postal Code
        /// </summary>
        /// <param name="PostalCode"></param>
        /// <returns></returns>
        public string InsertNewPostalCode(PostalCode PostalCode)
        {
            try
            {
                var request = new RestRequest("AddPostalCode", Method.Put);
                request.AddBody(PostalCode);
                var result = client.Execute(request);
                if (result.IsSuccessStatusCode)
                {
                    return string.Format("Successfully inserted {0}  as new PostalCode", PostalCode.PostalCode1);
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
        /// Edit PostalCode
        /// </summary>
        /// <param name="id"></param>
        /// <param name="PostalCode"></param>
        /// <returns></returns>
        public string EditPostalCode(int id, PostalCode PostalCode)
        {
            try
            {
                var request = new RestRequest("UpdatePostalCode/" + id, Method.Put);
                request.AddBody(PostalCode);
                var result = client.Execute(request);
                if (result.IsSuccessStatusCode)
                {
                    return string.Format("Successfully inserted {0} as new PostalCode", PostalCode.PostalCode1);
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
        /// Delete PostalCode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeletePostalCode(int id)
        {
            var response = "";
            try
            {
                var request = new RestRequest("RemovePostalCode/" + id, Method.Delete);
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