using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using WitchSaga.Application.KilledServices;

namespace WitchSaga.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Witch Saga Application console starting");

            //configure services
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IKillService, KillService>();
                })
                .UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<KillService>(host.Services);
            svc.Run();

        }

        //build config(talk to appsettings.json/manual connection
        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("NET_ENVIRONTMENT") ?? "Production.json"}", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

    }


}
