using Azure_Developer_Test.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure_Developer_Test.Interfaces
{
    public interface IEmployeeRepository
    {

        void Add(List<Employee> employees);
        double AverageSalary(List<Employee> employees);
        int TotalSalary(List<Employee> employees);
        int TotalEmployee(List<Employee> employees);
        IEnumerable<Employee> EmployeeAgeGreaterThan45(List<Employee> employees);

    }
    public interface IEmployeeService
    {
        Task<Response> GetEmployeesAsync();


    }
}
