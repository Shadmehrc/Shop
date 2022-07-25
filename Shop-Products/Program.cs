using System;
using System.Net;
using System.Security.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Shop_Products
{
    public class Program
    {
        private static IConfigurationRoot _config;
        private static string _applicationPort;
        public static void Main(string[] args)
        {
            InitialConfig(args);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel()
                        .UseIIS()
                        .UseStartup<Startup>()
                        .ConfigureKestrel((context, options) =>
                        {
                            options.Listen(IPAddress.Any, Convert.ToInt32(_applicationPort), listenOptions =>
                            {
                                listenOptions.UseHttps(o => o.SslProtocols = SslProtocols.Tls12);
                                listenOptions.UseConnectionLogging();
                                listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                            });
                        });
                });

        private static void InitialConfig(string[] args)
        {
            var env = new WebHostBuilder();
            var environmentName = env.GetSetting("environment");

            _config = new ConfigurationBuilder().AddCommandLine(args)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            _applicationPort = _config["AppPort"];
        }
    }
}