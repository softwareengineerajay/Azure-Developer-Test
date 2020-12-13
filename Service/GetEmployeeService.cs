using Azure_Developer_Test.Interfaces;
using Azure_Developer_Test.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Azure_Developer_Test.Service
{

    class GetEmployeeService : IEmployeeService
    {
        public async Task<Response> GetEmployeesAsync()
        {


            HttpClient client = new HttpClient();

            var url = "http://dummy.restapiexample.com/api/v1/employees";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Response>(await response.Content.ReadAsStringAsync());

        }



    }
}
