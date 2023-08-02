using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers;
public class NotificationController : Controller
{
    private readonly NotificationManager _notificationManager;
    private readonly Context _db;
    
    public NotificationController(Context db)
    {
        _db = db;
        _notificationManager = new NotificationManager(new EfNotificationRepository(_db));
    }
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