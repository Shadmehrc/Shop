using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            //Host.CreateDefaultBuilder(args)
            //    .ConfigureWebHostDefaults(webBuilder =>
            //    {
            //        webBuilder
            //            .UseKestrel()
            //            .UseIIS()
            //            .UseUrls($"http://*:{_applicationPort}")
            //            .UseStartup<Startup>();
            //    });
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();

                })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<KestrelServerOptions>(
                        context.Configuration.GetSection("Kestrel"));
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseUrls($"http://*:{_applicationPort}");
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