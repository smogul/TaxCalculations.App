using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxCalculationsAPI.Models;

namespace TaxCalculationsAPI.Controllers
{
    /// <summary>
    /// Employee Controller
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// loggging and dbcontext
        /// </summary>
        private Db_TaxCalculationContext _employeeContext;

        private ILogger<EmployeeController> logger;

        public EmployeeController(Db_TaxCalculationContext employeeContext, ILogger<EmployeeController> _logger)
        {
            _employeeContext = employeeContext;
            logger = _logger;
            _logger.LogInformation("created EmpController");
        }

        /// <summary>
        /// Get All Employees records
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeContext.Employees.ToListAsync();
                if (employees != null)
                {
                    return Ok(employees);
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
        /// Get Employee record By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public Employee GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeContext.Employees.Where(x => x.Id == id).FirstOrDefault();
                if (employee != null)
                {
                    return employee;
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

            return new Employee();
        }

        /// <summary>
        /// Add Employee record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut()]
        public string AddEmployee(Employee employee)
        {
            var response = "";
            try
            {
                var addEmployee = _employeeContext.Employees.Add(employee);
                if (addEmployee != null)
                {
                    _employeeContext.SaveChanges();
                    response = string.Format("Successfully inserted {0} {1} as new employee", employee.FirstName, employee.LastName);
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
                response = string.Format("Could not insert {0}. Error returned: {1}. Please check logs for more details", employee.FirstName + " " + employee.LastName, exception.Message);
            }
            finally
            {
                //dispose nlog once complete
                NLog.LogManager.Shutdown();
            }

            return response;
        }

        /// <summary>
        /// Update Employee record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public string UpdateEmployee(int? id, Employee employee)
        {
            var response = "";
            try
            {
                var index = _employeeContext.Employees.Where(c => c.Id == id);

                if (index != null)
                {
                    _employeeContext.Employees.Update(employee);
                    _employeeContext.SaveChanges(true);
                    response = string.Format("Successfully updated {0} {1} as new employee", employee.FirstName, employee.LastName);
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
                response = string.Format("Could not insert {0}. Error returned: {1}. Please check logs for more details", employee.FirstName + " " + employee.LastName, exception.Message);
            }
            finally
            {
                //dispose nlog once complete
                NLog.LogManager.Shutdown();
            }
            return response;
        }

        /// <summary>
        /// Remove Employee record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public string RemoveEmployee(int id)
        {
            var response = "";
            var employee = new Employee();
            try
            {
                employee = _employeeContext.Employees.Where(x => x.Id == id).FirstOrDefault();

                if (employee != null)
                {
                    _employeeContext.Employees.Remove(employee);
                    _employeeContext.SaveChanges();

                    response = string.Format("Successfully removed {0} {1} as new employee", employee.FirstName, employee.LastName);
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
                response = string.Format("Could not insert {0}. Error returned: {1}. Please check logs for more details", employee.FirstName + " " + employee.LastName, exception.Message);
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