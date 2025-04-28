using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationSystem.Infrastructure;

public static class MassTransitConfig
{
    // src/NotificationSystem.Infrastructure/MassTransitConfig.cs
    public static void AddMassTransitWithRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration.GetConnectionString("RabbitMq"));

                // Configure message routing
                cfg.ConfigureEndpoints(context);
            });
        });
    }
}

