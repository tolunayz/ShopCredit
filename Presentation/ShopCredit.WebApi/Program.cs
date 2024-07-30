using ShopCredit.Application.CQRS.Handlers.AdminHandlers;
using ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers;
using ShopCredit.Application.CQRS.Handlers.CustomerHandlers;
using ShopCredit.Application.Interfaces;
using ShopCredit.Application.Services;
using ShopCredit.Infrastructure.Context;
using ShopCredit.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ShopCreditContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

//Customer Builder
builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerAndAccountRepository, CustomerAndAccount>();

builder.Services.AddApplicationServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
