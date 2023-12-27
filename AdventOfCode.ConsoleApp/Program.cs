using System;
using AdventOfCode.ConsoleApp.Bootstrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

static void RegisterServices(HostBuilderContext context, IServiceCollection services)
{
    var config = new ConfigurationBuilder()
       .SetBasePath(Environment.CurrentDirectory)
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
       .Build();

    LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));

    services
        .AddLogging(loggingBuilder =>
        {
            // configure Logging with NLog
            loggingBuilder.ClearProviders();
            loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            loggingBuilder.AddNLog(config);
        })
        .AddPuzzles()
        .AddSingleton<Application>();
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices(RegisterServices);
}

var logger = LogManager.GetCurrentClassLogger();
try
{
    using IHost host = CreateHostBuilder(args).Build();
    logger.Info("Start application...");

    var app = host.Services.GetRequiredService<Application>();
    app.Run(args);
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    logger.Info("End application");
    LogManager.Shutdown();
}
