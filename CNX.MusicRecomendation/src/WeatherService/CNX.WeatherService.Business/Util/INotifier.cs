using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.WeatherService.Business.Util
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
