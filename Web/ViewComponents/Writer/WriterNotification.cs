using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents.Writer;

public class WriterNotification : ViewComponent
{
    NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
    public IViewComponentResult Invoke()
    {
        var result = _notificationManager.GetAll();
        return View(result);
    }
}