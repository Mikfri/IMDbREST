using IMDbLib.DataContext;
using IMDbLib.Models;
using IMDbLib.Repository;
using IMDbLib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// Mine services starter her:
builder.Services.AddDbContext<IMDb_Context>();
builder.Services.AddScoped<MovieService>();
builder.Services.AddTransient<IGRepository<MovieBase>, GRepository<MovieBase>>();

// Denne kode er til at løse problemet med at der er en reference loop i vores data - men det er ikke nok..
// vi bør istedet bruge DTO'er
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);


//builder.Services.AddSingleton(new PersonService());


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

app.Run();