using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AwesomeMusicManager.AlbumService.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
//            var config = new ConfigurationBuilder()
//                        .AddCommandLine(args)
//                        .AddJsonFile("appsettings.json")
//                        .AddEnvironmentVariables()
//                        .Build();
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}