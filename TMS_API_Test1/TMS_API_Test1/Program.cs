using Microsoft.EntityFrameworkCore;
using TMS_API_Test1.Middleware;
using TMS_API_Test1.Models;
using TMS_API_Test1.Service;
using TMS_API_Test1.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IWarhousesManagerService,  WarhousesManagerService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

var app = builder.Build();

app.MapRazorPages();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExeptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
