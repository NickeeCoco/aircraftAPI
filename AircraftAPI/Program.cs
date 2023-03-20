using AircraftCore.Handlers.Commands;
using AircraftCore.Handlers.Queries;
using AircraftCore.Interfaces;
using AircraftDomain.Models;
using AircraftInfrastructure.Data;
using AircraftInfrastructure.Extensions;
using AircraftInfrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersService();
builder.Services.AddDatabaseRegistry();
/*builder.Services.AddDbContext<AircraftContext>(opt =>
{
opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("AircraftAPI"));
});*/
builder.Services.AddServiceRegistry();
builder.Services.AddAuthenticationService();
builder.Services.AddCorsService();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatRService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
