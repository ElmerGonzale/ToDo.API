using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ToDo.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Agrega el servicio para la cadena a la base de datos SQL server
builder.Services.AddDbContext<AppDbContext>
    (options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();



app.MapGet("/", () 
    => Results.Ok("Hola a todos!"));

app.MapGet("/bienvenidos", () 
    => Results.NotFound("No se encontró el recurso"));

app.MapPost("/todo", () => "Se agregó un pendiente");

app.Run();