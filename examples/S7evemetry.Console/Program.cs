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
                    services.AddSingleton<SetupRepository>();
                    services.AddSingleton<CosmosDemoCarLap>();
                    services.AddSingleton<CosmosDemoParticipant>();
                    services.AddSingleton<CosmosDemoSetup>(); 
                    services.AddHostedService<CosmosDemoHostedService>();

                    CosmosClientBuilder clientBuilder = new CosmosClientBuilder("AccountEndpoint=https://s7evemetry-sata.documents.azure.com:443/;AccountKey=QPAzzue4MKE3bSwnT2TElpGC98XOY2SZgd6SrIGWVLC5iFsy27feYDNV4ZzW4EbNtkFqwlgZ5GBfmwPqtgmF0Q==;");
                    var client = clientBuilder.WithConnectionModeDirect().Build();
                    services.AddSingleton(client);
                });
		}
    }
}
