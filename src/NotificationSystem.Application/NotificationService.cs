using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using NotificationSystem.Domain;
using NotificationSystem.Infrastructure;
using NotificationSystem.Messaging;

namespace NotificationSystem.Application;

public class NotificationService
{
    private readonly MongoDbContext _dbContext;
    private readonly IPublishEndpoint _publishEndpoint;

    public NotificationService(MongoDbContext dbContext, IPublishEndpoint publishEndpoint)
    {
        _dbContext = dbContext;
        _publishEndpoint = publishEndpoint;
    }

    public async Task CreateNotificationAsync(Notification notification)
    {
        await _dbContext.Notifications.InsertOneAsync(notification);

        var message = new NotificationMessage
        {
            Id = notification.Id,
            Recipient = notification.Recipient,
            Message = notification.Message,
            Channel = notification.Channel.ToString()
        };

        await _publishEndpoint.Publish(message);
    }
}

