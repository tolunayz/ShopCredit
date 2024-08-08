using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ShopCredit.Application.Behaviors;
using ShopCredit.Application.CQRS.EventHandlers;
using ShopCredit.Application.CQRS.Handlers.NotificationHandlers;
using ShopCredit.Application.Interfaces;
using StackExchange.Redis;
using System.Reflection;
using System.Runtime;

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
                EndPoints = { "localhost:6379" }, // Update this with your Redis server details
                AbortOnConnectFail = false // This will make the connection retry if the first attempt fails
            };

            var multiplexer = ConnectionMultiplexer.Connect(configurationOptions);
            services.AddSingleton<IConnectionMultiplexer>(multiplexer);

            services.AddScoped<NotificationSender>();



        }
    }
       
    }

