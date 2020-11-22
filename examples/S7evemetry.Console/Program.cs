using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using S7evemetry.Console._2019;
using S7evemetry.Udp;
using S7evemetry.F1_2019.Listeners;
using S7evemetry.F1_2017.Listeners;
using S7evemetry.Console._2017;
using S7evemetry.Console.CosmosDemo;
using S7evemetry.Console.Data;
using Microsoft.Azure.Cosmos.Fluent;
using S7evemetry.F1_2020.Listeners;

namespace S7evemetry.Console
{
    class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			return Host.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration((hostingContext, config) =>
				{
					config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", true);
                })
				.ConfigureServices((hostingContext, services) =>
				{
					services.Configure<UdpListenerSettings>(hostingContext.Configuration.GetSection("UdpSettings"));
        
                    services.AddSingleton<F1_2020Listener>();
                    services.AddSingleton<CarLapRepository>();
                   // services.AddSingleton<SetupRepository>();
                    services.AddSingleton<CosmosDemoCarLap>();
                    //services.AddSingleton<CosmosDemoSetup>();
                    //services.AddSingleton<CosmosDemoEvent>();
                    services.AddHostedService<CosmosDemoHostedService>();

                    CosmosClientBuilder clientBuilder = new CosmosClientBuilder(hostingContext.Configuration["CosmosConnectionString"]);
                    var client = clientBuilder.WithConnectionModeDirect().Build();
                    services.AddSingleton(client);
                });
		}
    }
}
