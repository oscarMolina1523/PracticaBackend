using Aplication.Commands;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Servicios;
using Domain.UnitOfWork;
using Infrastructure;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConexionDB");
// Add services to the container.
builder.Services.AddDbContext<SeguridadContexto>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IService, Service>();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(CreateCategoriaCommand).Assembly);
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
