using MassTransit;
using NotificationSystem.EmailWorker;
using NotificationSystem.Messaging;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<EmailNotificationConsumer>(); // lub PushNotificationConsumer

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(hostContext.Configuration.GetConnectionString("RabbitMq"));
                cfg.ReceiveEndpoint("email-queue", e =>
                {
                    e.ConfigureConsumer<EmailNotificationConsumer>(context);
                });
            });
        });
    });

builder.Build().Run();
