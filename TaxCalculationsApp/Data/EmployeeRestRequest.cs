using Newtonsoft.Json;
using RestSharp;
using TaxCalculationsApp.Models;

namespace TaxCalculationsApp.Data
{
    /// <summary>
    /// Employee Rest Request class.
    /// </summary>
    public class EmployeeRestRequest
    {
        private RestClient client = new RestClient("https://localhost:7054/api/Employee/");
        private ILogger<EmployeeRestRequest> logger;

        public EmployeeRestRequest(ILogger<EmployeeRestRequest> _logger)
        {
            logger = _logger;
            _logger.LogInformation("created EmployeeRestRequest");
        }

        public EmployeeRestRequest()
        {
        }

        /// <summary>
        /// Retrieve list of All Employees
        /// </summary>
        /// <returns></returns>
        public List<Employee> RetrieveAllEmployees()
        {
            var employees = new List<Employee>();
            try
            {
                var request = new RestRequest("GetAllEmployees", Method.Get);
                var result = client.Execute<List<Employee>>(request);
                if (result != null)
                {
                    employees = result.Data;
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

            return employees;
        }

        /// <summary>
        /// Get Single Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetSingleEmployee(int id)
        {
            var employee = new Employee();
            try
            {
                var request = new RestRequest("GetEmployeeById/" + id, Method.Get);
                var result = client.Execute(request);
                if (result != null)
                {
                    employee = JsonConvert.DeserializeObject<Employee>(result.Content);
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
            return employee;
        }

        /// <summary>
        /// Insert New Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string InsertNewEmployee(Employee employee)
        {
            try
            {
                var request = new RestRequest("AddEmployee", Method.Put);
                request.AddBody(employee);
                var result = client.Execute(request);
                if (result.IsSuccessStatusCode)
                {
                    return string.Format("Successfully inserted {0} {1} as new employee", employee.FirstName, employee.LastName);
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
        /// Edit Employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string EditEmployee(int id, Employee employee)
        {
            try
            {
                var request = new RestRequest("UpdateEmployee/" + id, Method.Put);
                request.AddBody(employee);
                var result = client.Execute(request);
                if (result.IsSuccessStatusCode)
                {
                    return string.Format("Successfully inserted {0} {1} as new employee", employee.FirstName, employee.LastName);
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
        /// Delete Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteEmployee(int id)
        {
            var response = "";
            try
            {
                var request = new RestRequest("RemoveEmployee/" + id, Method.Delete);
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