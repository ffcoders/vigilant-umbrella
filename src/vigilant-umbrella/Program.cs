using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using vigilant_umbrella_application.Services.V1.Countries;
using vigilant_umbrella_infrastructure.Context;
using vigilant_umbrella_infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<VigilantUmbrellaDbContext>(options =>
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

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IVigilantUmbrellaDbContext, VigilantUmbrellaDbContext>();

builder.Services.AddScoped<ICountriesAppServices, CountriesAppServices>();

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
