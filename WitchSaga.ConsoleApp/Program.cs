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
            #region Serilog Configuration
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            #endregion

            Log.Logger.Information("Witch Saga Application console starting");

            #region Setup DI
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IKillService, KillService>();
                })
                .UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<KillService>(host.Services);
            #endregion

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
