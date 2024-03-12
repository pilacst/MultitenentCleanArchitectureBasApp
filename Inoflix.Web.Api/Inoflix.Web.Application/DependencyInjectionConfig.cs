using FluentValidation;
using Inoflix.Web.Application.Features.Users.Command;
using Inoflix.Web.Application.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Inoflix.Web.Application
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, 
            ConfigurationManager config)
        {
            var curruntAssembly = typeof(DependencyInjectionConfig).Assembly;
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(curruntAssembly);
                config.Lifetime = ServiceLifetime.Scoped;
            });

            services.Configure<TokenConfigOptions>(config.GetSection(TokenConfigOptions.JWT));
            //foreach (System.Reflection.TypeInfo typeIntreface in curruntAssembly.GetTypes().Where(x => x.IsInterface == true).Cast<TypeInfo>())
            //{
            //    if (typeIntreface.ImplementedInterfaces.Any() && typeIntreface.ImplementedInterfaces.Where(x => x.Name == typeof(IBaseService).Name).Any())
            //    {
            //        foreach (var typeImplementation in from TypeInfo typeInfo2 in Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsInterface == false)
            //                                           where typeInfo2.ImplementedInterfaces.Any() && typeInfo2.ImplementedInterfaces.Where(x => x.Name == typeIntreface.Name).Any()
            //                                           select typeInfo2)
            //        {
            //            services.AddScoped(typeIntreface, typeImplementation);
            //        }
            //    }
            //}

            foreach (var type in curruntAssembly.GetTypes().Where(x => x.CustomAttributes.Where(y => y.AttributeType == typeof(InoflixDIRegistyServiceAttribute)).Any()))
            {
                var attribute = type.GetCustomAttribute<InoflixDIRegistyServiceAttribute>();
                if (attribute != null)
                {
                    var serviceInterface = attribute.ServiceInterface;
                    var lifetime = attribute.Lifetime;

                    if (serviceInterface.IsAssignableFrom(type))
                    {
                        if (lifetime == LifetimeOfService.Scoped)
                        {
                            services.AddScoped(serviceInterface, type);
                        }

                        if (lifetime == LifetimeOfService.Transient)
                        {
                            services.AddTransient(serviceInterface, type);
                        }

                        if (lifetime == LifetimeOfService.Singleton)
                        {
                            services.AddSingleton(serviceInterface, type);
                        }
                    }
                }
            }

            services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();

            return services;
        }
    }
}
