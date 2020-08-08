using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.MusicRecomendation.Business.Util
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
