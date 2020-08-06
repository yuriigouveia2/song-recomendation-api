using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.UserService.Business.Utils
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
