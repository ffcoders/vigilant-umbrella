using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using vigilant_umbrella_application.Services.V1.Countries;
using vigilant_umbrella_infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<VigilantUmbrellaDbContext>(options =>
{
    options.UseInMemoryDatabase(databaseName: "testDatabase");
    // Todo: Create a database instance to use
    //options.UseSqlite(builder.Configuration.GetConnectionString("MainConnectionString"))
});

builder.Services.AddScoped<ICountriesAppServices, CountriesAppServices>();
builder.Services.AddScoped<IVigilantUmbrellaDbContext, VigilantUmbrellaDbContext>();

var app = builder.Build();

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
