using Microsoft.EntityFrameworkCore;
using WebApplication1.Managers.Implemantations;
using WebApplication1.Models;
using WebApplication1.Managers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskContext")));
builder.Services.AddScoped<ITaskManager, TaskManager>();

 

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

app.UseAuthorization();

app.MapControllers();

app.Run();