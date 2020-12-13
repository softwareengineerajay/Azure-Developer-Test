using Azure_Developer_Test;
using Azure_Developer_Test.Interfaces;
using Azure_Developer_Test.Service;
using DependencyInjectionFunctions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace DependencyInjectionFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IEmployeeService, GetEmployeeService>();
            // or one of the options below
            builder.Services.AddSingleton<IEmployeeRepository, MockEmployee>();
           
            //builder.Services.AddDbContext<EmployeeDataContext>(
            //    options => options.UseSqlServer(SqlConnection));
            // builder.Services.AddTransient<IRepository, Repository>();
            builder.Services.AddLogging();
        }
    }


}

