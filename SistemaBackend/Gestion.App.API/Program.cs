using GestionApp.Domain.Interfaces;
using GestionApp.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Conexion AzureDB
var connectionString = builder.Configuration.GetConnectionString("AzureConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        // Esto le dice a .NET: "Si Azure está durmiendo, reintentá un par de veces antes de fallar"
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    }));

// Inyección del Repositorio Genérico (Una instancia por cada petición HTTP)

/*
 * ¿Qué significa AddScoped?
Significa que cada vez que un usuario desde Angular o desde su celular haga una petición (ej: "Tráeme los productos"),
.NET va a crear una sola copia de tu Repositorio y la va a destruir cuando le devuelva la respuesta. Es súper eficiente y no satura la memoria.
 */
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
