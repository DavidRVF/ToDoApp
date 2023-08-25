using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Models;
using Proyecto.Services;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BdintroContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"),sqlServerOptionsAction => sqlServerOptionsAction.CommandTimeout(60));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<UsuarioService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
