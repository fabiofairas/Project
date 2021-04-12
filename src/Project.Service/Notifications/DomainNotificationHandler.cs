using MediatR;
using Project.Model.DTOs;
using Project.Model.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Service.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);

            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotification()
        {
            return GetNotifications().Any();
        }

        public virtual IEnumerable<NotificationResponse> ListNotifications()
        {
            return GetNotifications().Select(e => new NotificationResponse() { Notification = e.Value });
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
