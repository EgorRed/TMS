using Microsoft.EntityFrameworkCore;
using TMS_API_Test1.Middleware;
using TMS_API_Test1.Models;
using TMS_API_Test1.Service;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
//builder.Services.AddDbContext<ProductContext>(opt =>
//    opt.UseInMemoryDatabase("ProductList"));
builder.Services.AddSingleton<IWarhousesManagerService,  WarhousesManagerService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



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
