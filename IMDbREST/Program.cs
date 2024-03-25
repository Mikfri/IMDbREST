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

builder.Services.AddDbContext<IMDb_Context>();
//builder.Services.AddDbContext<IMDb_Context>(options => options.UseSqlServer(Configuration.GetConnectionString(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IMDb_DB; Integrated Security=True;")));
builder.Services.AddScoped<MovieService>();
builder.Services.AddTransient<IGRepository<MovieBase>, GRepository<MovieBase>>();

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
