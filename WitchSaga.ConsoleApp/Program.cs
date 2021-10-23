using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

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
        }

        //build config(talk to appsettings.json/manual connection
        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("NET_ENVIRONTMENT") ?? "Production"}", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

    }
}
