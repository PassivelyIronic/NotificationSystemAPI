using MassTransit;
using NotificationSystem.PushWorker;
using NotificationSystem.Messaging;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<PushNotificationConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(hostContext.Configuration.GetConnectionString("RabbitMq"));

                // Konfiguracja endpointu dla powiadomieñ Push
                cfg.ReceiveEndpoint("push-notifications", e =>
                {
                    e.ConfigureConsumer<PushNotificationConsumer>(context);
                });
            });
        });
    });

builder.Build().Run();
