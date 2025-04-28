using MassTransit;
using NotificationSystem.Messaging;

namespace NotificationSystem.PushWorker;

public class PushNotificationConsumer : IConsumer<NotificationMessage>
{
    public async Task Consume(ConsumeContext<NotificationMessage> context)
    {
        var message = context.Message;

        if (message.Channel == "Push")
        {
            Console.WriteLine($"[PUSH] To: {message.Recipient}, Message: {message.Message}");
        }
    }
}
