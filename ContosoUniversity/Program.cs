using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ContosoUniversity.Models;
using ContosoUniversity.Data;

namespace ContosoUniversity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetService<ContosoUniversityContext>();
                    DbInitializer.Initialize(context);
                }
                catch(Exception e)
                {
                    var logger = services.GetService <ILogger<Program>>();
                    logger.LogError(e, "An error occurred creating the DB.");
                }
            }
           
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((host, config) => config.AddEnvironmentVariables("ASPNETCOR_"))
                .ConfigureLogging((host, logging) =>
                {
                    //logging.
                })
                .UseStartup<Startup>();
    }
}
