using Common;
using Domain.Mapping;
using Domain.WineOrders;
using Infrastructure.AzureServiceBusClient;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

[assembly: FunctionsStartup(typeof(DionysosRouter.Startup))] //specify the class that acts as the Functions startup


namespace DionysosRouter
{
    public class Startup : FunctionsStartup
    {

        private const string serviceBusConnectionStringVar = "serviceBusConnectionString";

        public override void Configure(IFunctionsHostBuilder builder)
        {

            // Register Configuration as a singleton
            builder.Services.AddSingleton<IConfiguration>(new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("local.settings.json", true, true)
            .AddEnvironmentVariables()
            .Build());

            var serviceProvider = builder.Services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            builder.Services.Configure<AzureServiceBusOptions>(options =>
            {
                options.serviceBusConnectionString = configuration[serviceBusConnectionStringVar];
            });

            builder.Services.AddSingleton<IAzureServiceBusClient, AzureServiceBusClient>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RequestItalianRedWineDtoHandler).Assembly));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
