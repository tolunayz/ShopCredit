using MediatR;
using ShopCredit.Application.Behaviors;
using ShopCredit.Application.Interfaces;
using ShopCredit.Application.Services;
using ShopCredit.Infrastructure.Context;
using ShopCredit.Infrastructure.Repositories;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IShopCreditContext, ShopCreditContext>();

// Add services to the container.
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
builder.Services.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));

//builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
//{
//    var configuration = ConfigurationOptions.Parse("your-redis-connection-string", true);
//    return ConnectionMultiplexer.Connect(configuration);
//});

builder.Services.AddTransient<IDatabase>(sp =>
{
    var connectionMultiplexer = sp.GetRequiredService<IConnectionMultiplexer>();
    return connectionMultiplexer.GetDatabase();
});
builder.Services.AddSingleton<IRedisCacheService, RedisCacheService>();

//Customer Builder
builder.Services.AddControllers();
//RabbitMQ

builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQ"));
//builder.Services.AddSingleton<NotificationSender>();

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
