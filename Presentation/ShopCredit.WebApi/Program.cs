using MediatR;
using ShopCredit.Application.Behaviors;
using ShopCredit.Application.Interfaces;
using ShopCredit.Application.Services;
using ShopCredit.Infrastructure.Context;
using ShopCredit.Infrastructure.Repositories;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database context
builder.Services.AddDbContext<IShopCreditContext, ShopCreditContext>();

// Repositories
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
builder.Services.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));

// Redis Cache
builder.Services.AddTransient<IDatabase>(sp =>
{
    var connectionMultiplexer = sp.GetRequiredService<IConnectionMultiplexer>();
    return connectionMultiplexer.GetDatabase();
});
builder.Services.AddSingleton<IRedisCacheService, RedisCacheService>();

// RabbitMQ
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQ"));

// Custom Repositories
builder.Services.AddTransient<ICustomerAndAccountRepository, CustomerAndAccount>();

// MediatR Behaviors
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// HttpClient for InventoryGuard API
builder.Services.AddHttpClient("InventoryGuardApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7215/api/");
});

// Controllers
builder.Services.AddControllers();

// Swagger
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
