using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibbraneo.ToDoList.Application.Utils
{
    public static class NotificationHelper
    {
        public static List<Notification> BuildNotifications(params Notification[] notifications)
            => notifications.ToList();

        public static string GetNotificationsMessages(IEnumerable<Notification> notifications)
            => notifications.Any() ? string.Join(", ", notifications) : string.Empty;
    }
}
