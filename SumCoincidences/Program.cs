// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SumCoincidences;
using SumCoincidencesLibrary.BusinessLogic;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IOperations, Operations>();
            services.AddSingleton<App>();
        });
}
