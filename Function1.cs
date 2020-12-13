using Azure_Developer_Test.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Azure_Developer_Test
{
    public class EmployeeFunction
    {

        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeFunction(IEmployeeService _employeeService, IEmployeeRepository _employeeRepository)
        {
            this._employeeService = _employeeService;
            this._employeeRepository = _employeeRepository;
        }

        [FunctionName("AddEmployee")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            try
            {
                var data = await _employeeService.GetEmployeesAsync();

                try
                {
                    log.LogInformation("Adding data to database");
                    _employeeRepository.Add(data.Data);
                }
                catch (Exception exe)
                {
                    log.LogError(exe.Message);

                }
                try
                {
                    log.LogInformation("Print the Avg salary");
                    _employeeRepository.AverageSalary(data.Data);
                }
                catch (Exception exe)
                {
                    log.LogError(exe.Message);

                }
                try
                {
                    log.LogInformation("Total No of Employees");
                    _employeeRepository.TotalEmployee(data.Data);
                }
                catch (Exception exe)
                {
                    log.LogError(exe.Message);

                }
                try
                {
                    log.LogInformation("Print Total salary");
                    _employeeRepository.TotalSalary(data.Data);
                }
                catch (Exception exe)
                {
                    log.LogError(exe.Message);


                }
                try
                {
                    log.LogInformation("Fetch all the employee data from the httprequest and print the employee's details whose age is greater than 45.");
                    _employeeRepository.EmployeeAgeGreaterThan45(data.Data);
                }
                catch (Exception exe)
                {
                    log.LogError(exe.Message);

                }



            }
            catch (Exception exe)
            {
                throw;
            }

            return new OkResult();
        }

    }
}
