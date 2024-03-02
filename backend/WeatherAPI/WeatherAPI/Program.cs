using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WeatherAPI.Services;

Log.Logger = new LoggerConfiguration()
  .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}|{Level:u3}|{SourceProgram}|{SourceContext}|{Message:1j}{NewLine}{Exception}")
  .CreateBootstrapLogger();

Log.Information("Starting up Weather App Backend");

try
{
  var builder = WebApplication.CreateBuilder(args);
  
  builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services));

  builder.Services.AddScoped<IWeatherService, WeatherService>();
  builder.Services.AddControllers();
  
  var app = builder.Build();

  app.UseRouting();
  app.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");
  app.MapFallbackToFile("index.html");
  app.Run();
}
catch (Exception ex)
{
  Log.Fatal(ex, "Failed to start Weather App Backend.");
  Environment.ExitCode = -1;
}
finally
{
  Log.Information("Weather App Backend shut down completed.");
  Log.CloseAndFlush();
}
