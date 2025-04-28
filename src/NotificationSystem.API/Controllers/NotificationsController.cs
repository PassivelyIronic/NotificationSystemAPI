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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Notification notification)
    {
        // Ustawienie domyślnego id i statusu, jeśli nie zostały podane
        if (notification.Id == Guid.Empty)
        {
            notification.Id = Guid.NewGuid(); // generowanie unikalnego ID
        }

        if (notification.Status == 0)
        {
            notification.Status = NotificationStatus.Pending;  // lub NotificationStatus.<wybranyStatus>    
        }

        // Tworzenie powiadomienia
        await _notificationService.CreateNotificationAsync(notification);

        return Ok();
    }

}

