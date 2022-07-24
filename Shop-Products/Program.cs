using System;
using Microsoft.AspNetCore.Hosting;
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
                 webBuilder.UseStartup<Startup>();
                 webBuilder.UseKestrel(opts =>
                 {
                     opts.ListenAnyIP(Convert.ToInt32(_applicationPort));
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
