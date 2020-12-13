using Newtonsoft.Json;
using System.Collections.Generic;

namespace Azure_Developer_Test.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Employee
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("employee_name")]
        public string EmployeeName { get; set; }

        [JsonProperty("employee_salary")]
        public int EmployeeSalary { get; set; }

        [JsonProperty("employee_age")]
        public int EmployeeAge { get; set; }

        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }
    }

    public class Response
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public List<Employee> Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }



}
