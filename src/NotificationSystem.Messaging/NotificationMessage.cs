using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Messaging;

public class NotificationMessage
{
    public Guid Id { get; set; }
    public string Recipient { get; set; }
    public string Message { get; set; }
    public string Channel { get; set; }
}

