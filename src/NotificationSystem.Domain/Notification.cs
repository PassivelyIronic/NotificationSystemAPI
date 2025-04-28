using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Domain;

public enum NotificationChannel
{
    Email,
    Push
}

public enum NotificationStatus
{
    Pending = 0,
    Sent = 1,
    Failed = 2,
    Cancelled = 3
}

public class Notification
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Recipient { get; set; }
    public string Message { get; set; }
    public NotificationChannel Channel { get; set; }
    public DateTime ScheduledAt { get; set; }
    public NotificationStatus Status { get; set; } = NotificationStatus.Pending;
}
    