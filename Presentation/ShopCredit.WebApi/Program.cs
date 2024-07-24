using ShopCredit.Application.CQRS.Handlers.AdminHandlers;
using ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers;
using ShopCredit.Application.CQRS.Handlers.CustomerAccPaymentHandlers;
using ShopCredit.Application.CQRS.Handlers.CustomerHandlers;
using ShopCredit.Application.Interfaces;
using ShopCredit.Infrastructure.Context;
using ShopCredit.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ShopCreditContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//Customer Builder
builder.Services.AddControllers();
builder.Services.AddScoped<GetCustomerByIdQueryHandler>();
builder.Services.AddScoped<GetCustomerQueryHandler>();
builder.Services.AddScoped<CreateCustomerCommandHandler>();
builder.Services.AddScoped<UpdateCustomerCommandHandler>();
builder.Services.AddScoped<RemoveCustomerCommandHandler>();
//Admin Builder
builder.Services.AddScoped<GetAdminByIdQueryHandler>();
builder.Services.AddScoped<GetAdminQueryHandler>();
builder.Services.AddScoped<CreateAdminCommandHandler>();
builder.Services.AddScoped<UpdateAdminCommandHandler>();
builder.Services.AddScoped<RemoveAdminCommandHandler>();
//Customer Account Builder
builder.Services.AddScoped<GetCustomerAccountByIdQueryHandler>();
builder.Services.AddScoped<GetCustomerAccountQueryHandler>();
builder.Services.AddScoped<CreateCustomerAccountCommandHandler>();
builder.Services.AddScoped<RemoveCustomerAccountCommandHandler>();
builder.Services.AddScoped<UpdateCustomerAccountCommandHandler>();
//Customer Payment Builder
builder.Services.AddScoped<GetCustomerAccPaymentByIdQueryHandler>();
builder.Services.AddScoped<GetCustomerAccPaymentQueryHandler>();
builder.Services.AddScoped<CreateCustomerAccPaymentCommandHandler>();
builder.Services.AddScoped<UpdateCustomerAccPaymentCommandHandler>();
builder.Services.AddScoped<RemoveCustomerAccPaymentCommandHandler>();



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
