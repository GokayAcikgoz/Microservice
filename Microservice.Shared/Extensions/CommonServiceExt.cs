using FluentValidation;
using FluentValidation.AspNetCore;
using Microservice.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Shared.Extensions
{
    public static class CommonServiceExt
    {
        public static IServiceCollection AddCommonServiceExt(this IServiceCollection services, Type assembly)
        {
            services.AddHttpContextAccessor();
            services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(assembly));

            services.AddFluentValidation();
            services.AddValidatorsFromAssemblyContaining(assembly);
            services.AddAutoMapper(cfg => { }, assembly);
            services.AddScoped<IIdentityService, IdentityServiceFake>();

            return services;
        }
    }
}
