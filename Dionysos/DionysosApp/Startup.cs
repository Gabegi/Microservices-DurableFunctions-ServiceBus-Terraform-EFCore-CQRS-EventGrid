using Infrastructure.DataBase;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Application.Handlers;
using Application.Mapping;


[assembly: FunctionsStartup(typeof(DionysosApp.Startup))] //specify the class that acts as the Functions startup


namespace DionysosApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            // Register Configuration as a singleton, read settings, environment variables
            builder.Services.AddSingleton<IConfiguration>(new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("local.settings.json", true, true)
            .AddEnvironmentVariables()
            .Build());

            var serviceProvider = builder.Services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            builder.Services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseSqlServer(configuration["sqlDbConnectionString"], b => b.MigrationsAssembly("Infrastructure"));

            });

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RequestItalianRedWineHandler).Assembly));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
        }

    }
}
