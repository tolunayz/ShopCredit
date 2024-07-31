using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ShopCredit.Application.Services
{
    public static class ServicesRegistiration
    {
        public static void AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServicesRegistiration).Assembly));


            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
