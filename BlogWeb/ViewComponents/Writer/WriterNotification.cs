using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents.Writer;

public class WriterNotification : ViewComponent
{
    private readonly NotificationManager _notificationManager;
    private readonly Context _db;
    
    public WriterNotification(Context db)
    {
        _db = db;
        _notificationManager = new NotificationManager(new EfNotificationRepository(_db));
    }
    public IViewComponentResult Invoke()
    {
        var result = _notificationManager.GetAll();
        return View(result);
    }
}