using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Application;
using NotificationSystem.Domain;

namespace NotificationSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly NotificationService _notificationService;

    public NotificationsController(NotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    // src/NotificationSystem.API/Controllers/NotificationsController.cs
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Notification notification)
    {
        // Set default values if not provided
        if (notification.Id == Guid.Empty)
        {
            notification.Id = Guid.NewGuid();
        }

        if (notification.Status == 0)
        {
            notification.Status = NotificationStatus.Pending;
        }

        // Set scheduled time to current time if not specified
        if (notification.ScheduledAt == default)
        {
            notification.ScheduledAt = DateTime.UtcNow;
        }

        // Create notification and publish message
        await _notificationService.CreateNotificationAsync(notification);

        return CreatedAtAction(nameof(Create), new { id = notification.Id }, notification);
    }

}

