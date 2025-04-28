using NotificationSystem.Application;
using NotificationSystem.Infrastructure;
using MassTransit;
using Microsoft.OpenApi.Models; // dla Swaggera

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
