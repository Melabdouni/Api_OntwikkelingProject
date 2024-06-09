using MVC_Deel1.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration["ConnectionStrings:VastgoedNutsDbConnectionString"];
    builder.Services.AddDbContext<MVCDbContext>(o => o.UseMySql(
    connection, ServerVersion.AutoDetect(connection)));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/", (MVCDbContext mVCDbContext) =>
{
    return mVCDbContext.Buildings;
    
});

app.Run();

