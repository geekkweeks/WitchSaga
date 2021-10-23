using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using WitchSaga.Application.Dto;
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
                    services.AddTransient<IPeopleService, PeopleService>();
                })
                .UseSerilog()
                .Build();

            var killSvc = ActivatorUtilities.CreateInstance<KillService>(host.Services);

            var inputs = new List<PersonDto> 
            {
                new PersonDto
                {
                    Name = "Person A",
                    AgeOfDeath = 13,
                    YearOfDeath = 17
                }
            };
            killSvc.GetPeopleKilledInfo(inputs);           
            #endregion



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
