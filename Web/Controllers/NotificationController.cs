using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class NotificationController : Controller
{
    NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult NotificationList()
    {
        var result = _notificationManager.GetAll();
        return View(result);
    }
}