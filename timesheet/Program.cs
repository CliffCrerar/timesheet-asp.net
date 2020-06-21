using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Timesheet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // host
            var host = CreateHostBuilder(args);
            // host app configuration
            host.ConfigureAppConfiguration((HostBuilderContext hostContext, IConfigurationBuilder builder) =>
            {
                if (hostContext.HostingEnvironment.IsDevelopment())
                {
                    builder.AddUserSecrets<Program>();
                }
            });

            // build host
            host.Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
