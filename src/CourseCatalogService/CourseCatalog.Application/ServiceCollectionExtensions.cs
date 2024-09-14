﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CourseCatalog.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
