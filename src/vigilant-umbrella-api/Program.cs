using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using vigilant_umbrella_application.Services.V1.Countries;
using vigilant_umbrella_infrastructure.Context;
using vigilant_umbrella_infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) //load base settings
                         .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true) //load local settings
                         .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true); //load environment settings
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Configuration.AddEnvironmentVariables();

//Add support to logging with SERILOG
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Logging setup
// Using builder.Logging to setup logging providers
builder.Logging.ClearProviders(); // Clear default providers
builder.Logging.AddConsole(); // Add console logging
builder.Logging.AddDebug(); // Add debug logging

// Add services to the container.
var services = builder.Services;
services.AddControllers();
services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddDbContext<VigilantUmbrellaDbContext>(options =>
{
    var connection = builder.Configuration.GetConnectionString("DefaultConnection");
    if (!string.IsNullOrEmpty(connection))
    {
        options.UseSqlServer(connection);
    }
    else
    {
        options.UseInMemoryDatabase(databaseName: "testDatabase");
    }
});

services.AddTransient<IUnitOfWork, UnitOfWork>();
services.AddScoped<IVigilantUmbrellaDbContext, VigilantUmbrellaDbContext>();

builder.Services.AddScoped<ICountriesAppServices, CountriesAppServices>();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<VigilantUmbrellaDbContext>();
    await dbContext.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
