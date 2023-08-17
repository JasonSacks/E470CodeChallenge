using E470CodeChallenge.DbContexts;
using E470CodeChallenge.Factories;
using E470CodeChallenge.Repositories;
using E470CodeChallenge.Services;
using Microsoft.EntityFrameworkCore;


/**
 * 
 * Was going to add middleware for request reponse logger and also unhandled exception. However I am out of time today working on this
 * due to other commitments and wanted to get the code in today. Noting this to show I am aware, I beleive this examples
 * details my knowlege of C#.
 * */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<E470DbContext>( options => options.UseInMemoryDatabase("TestDb"));

builder.Services
    .AddTransient<ITransponderRepositoryFactory, TransponderRepositoryFactory>()
    .AddTransient<IVehicleRepository, VehicleRepository>()
    .AddTransient<IVehicleService, VehicleService>()
    .AddTransient<ITransponderService, TransponderService>();

builder.Logging.AddConsole();
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
