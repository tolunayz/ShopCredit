using FluentValidation;
using MediatR;
using ShopCredit.Application.Behaviors;
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
//ConfigureApiBehaviorOptions(delegate (ApiBehaviorOptions opt)
//        {
//            opt.InvalidModelStateResponseFactory = delegate (ActionContext _context)
//            {
//                string text = string.Join(Environment.NewLine, _context.ModelState.Values.Select((ModelStateEntry s) => string.Join(", ", s.Errors.Select((ModelError s) => s.ErrorMessage))));
//                return new ObjectResult(new BaseResponse<object>
//                {
//                    ErrorMessage = text,
//                    HasError = true,
//                    AlertMessage = text,
//                    AlertLevelEnum = AlertLevelEnum.Low,
//                    ResponseCodeEnum = ResponseCodeEnum.DefaultErrorCode
//                });
//            };
builder.Services.AddScoped<ICustomerAndAccountRepository, CustomerAndAccount>();

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
