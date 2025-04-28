using MassTransit;
using NotificationSystem.Messaging;

namespace NotificationSystem.EmailWorker;

// src/NotificationSystem.EmailWorker/EmailNotificationConsumer.cs
public class EmailNotificationConsumer : IConsumer<NotificationMessage>
{
    public async Task Consume(ConsumeContext<NotificationMessage> context)
    {
        var message = context.Message;

        if (message.Channel == "Email")
        {
            Console.WriteLine($"[EMAIL] Processing notification {message.Id} - To: {message.Recipient}, Message: {message.Message}");
            await Task.Delay(100); // Simulate some processing time
            Console.WriteLine($"[EMAIL] Successfully sent notification {message.Id}");
        }
    }
}
