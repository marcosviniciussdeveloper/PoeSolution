using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Poe.Infraestructure.Data;
using Poe.Infraestructure.Repositories;
using Poe.Modulo.ProcessMining.Interface;
using Poe.Modulo.ProcessMining.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PoeDbContext>(options =>
        options.UseNpgsql(connectionString
        ))
    ;

builder.Services.AddSingleton<IEventRepository , EventRepository>();
builder.Services.AddSingleton<IProcessMiningService , ProcessMiningService>();   


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();