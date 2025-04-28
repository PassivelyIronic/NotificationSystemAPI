using MassTransit;
using NotificationSystem.Messaging;
using NotificationSystem.PushWorker;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<PushNotificationConsumer>(); // lub PushNotificationConsumer

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(hostContext.Configuration.GetConnectionString("RabbitMq"));
                cfg.ReceiveEndpoint("push-queue", e =>
                {
                    e.ConfigureConsumer<PushNotificationConsumer>(context);
                });
            });
        });
    });

builder.Build().Run();
