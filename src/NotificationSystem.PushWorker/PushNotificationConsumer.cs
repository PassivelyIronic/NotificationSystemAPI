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
            Console.WriteLine($"[PUSH] Przetwarzanie powiadomienia {message.Id} - Do: {message.Recipient}, Wiadomość: {message.Message}");
            await Task.Delay(100); // Symulacja czasu przetwarzania
            Console.WriteLine($"[PUSH] Pomyślnie wysłano powiadomienie {message.Id}");
        }
    }
}
