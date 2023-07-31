using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents.Notification;

public class NotificationList :ViewComponent
{
    NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
    public IViewComponentResult Invoke()
    {
        var result = _notificationManager.GetAll();
        return View();
    }
    
}