using MassTransit;
using NotificationSystem.EmailWorker;
using NotificationSystem.Messaging;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        // src/NotificationSystem.EmailWorker/Program.cs
        // src/NotificationSystem.EmailWorker/Program.cs
        services.AddMassTransit(x =>
        {
            x.AddConsumer<EmailNotificationConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(hostContext.Configuration.GetConnectionString("RabbitMq"));

                // Configure endpoint for email notifications
                cfg.ReceiveEndpoint("email-notifications", e =>
                {
                    e.ConfigureConsumer<EmailNotificationConsumer>(context);
                });
            });
        });
    });

builder.Build().Run();
