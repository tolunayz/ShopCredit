using MediatR;
using ShopCredit.Application.Behaviors;
using ShopCredit.Application.Interfaces;
using ShopCredit.Application.Services;
using ShopCredit.Infrastructure.Context;
using ShopCredit.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IShopCreditContext, ShopCreditContext>();

// Add services to the container.
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
builder.Services.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));

//Customer Builder
builder.Services.AddControllers();

builder.Services.AddTransient<ICustomerAndAccountRepository, CustomerAndAccount>();
builder.Services.AddApplicationServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

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
