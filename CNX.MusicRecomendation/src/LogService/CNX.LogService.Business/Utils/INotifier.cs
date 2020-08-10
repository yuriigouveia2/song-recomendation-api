using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.LogService.Business.Utils
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
