using Azure_Developer_Test.Interfaces;
using Azure_Developer_Test.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Azure_Developer_Test
{


    public class MockEmployee : IEmployeeRepository
    {
     
        public void Add(List<Employee> employee)
        {

            DataTable employeeDataTable = employee.ToDataTable();
            string connectionString = Environment.GetEnvironmentVariable("connectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                connection.Open();
                bulkCopy.DestinationTableName = "TableName";
                try
                {
                    bulkCopy.WriteToServer(employeeDataTable);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }

        }

        public double AverageSalary(List<Employee> employees)
        {
            return employees.Average(x => x.EmployeeSalary);
        }

        public int TotalEmployee(List<Employee> employees)
        {
            return employees.Count();
        }
        public int TotalSalary(List<Employee> employees)
        {
            return employees.Sum(x => x.EmployeeSalary);
        }

        public IEnumerable<Employee> EmployeeAgeGreaterThan45(List<Employee> employees)
        {
            return employees.Where(x => x.EmployeeAge > 45);

        }
    }
}
