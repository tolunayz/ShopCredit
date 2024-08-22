using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ShopCredit.Application.CQRS.EventHandlers;
using StackExchange.Redis;
using System.Reflection;

namespace ShopCredit.Application.Services
{
    public static class ServicesRegistiration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServicesRegistiration).Assembly));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQSettings"));


            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    var settings = context.GetRequiredService<IOptions<RabbitMQSettings>>().Value;

                    cfg.Host(
                        host: settings.Hostname,
                        port: 5672,
                        virtualHost: settings.Username, 
                        configure:  h => {
                            h.Username(settings.Username);
                            h.Password(settings.Password);
                        });
                    cfg.ReceiveEndpoint("notifications", e =>
                    {
                        e.ConfigureConsumer<ConsumeHandler>(context);
                    });
                });
                x.AddConsumer<ConsumeHandler>();
            });

            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { "localhost:6379" }, 
                AbortOnConnectFail = false 
            };

            var multiplexer = ConnectionMultiplexer.Connect(configurationOptions);
            services.AddSingleton<IConnectionMultiplexer>(multiplexer);




        }
    }
       
    }

