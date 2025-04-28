using MassTransit;
using NotificationSystem.Messaging;

namespace NotificationSystem.EmailWorker;

public class EmailNotificationConsumer : IConsumer<NotificationMessage>
{
    public async Task Consume(ConsumeContext<NotificationMessage> context)
    {
        var message = context.Message;

        if (message.Channel == "Email")
        {
            Console.WriteLine($"[EMAIL] To: {message.Recipient}, Message: {message.Message}");
        }
    }
}
