// Создать веб-приложение для управления заказами в интернет-магазине с использованием паттерна MVC.
//
// 1. Необходимо создать модели - продукт, заказ, покупатель и создать миграцию.
//
// 2. Необходимо создать функционал для взаимодействия с бд.
//
// 3. Напишите контроллеры для создания, обновления, получения всех сущностей (продукты, заказы, покупатели)
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Interfaces;
using WebApplication1.Models.Models;
using WebApplication1.Models.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DatabaseContext")));
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IOrderManager, OrderManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();


var app = builder.Build();


Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Program>();
    });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();