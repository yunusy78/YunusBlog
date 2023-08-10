using BlogWeb.Areas.Admin.Models;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers;
[Area("Admin")]
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
        var result = _notificationManager.GetAll();
        return View(result);
    }
    
    public IActionResult Add()
    {
        var viewModel = new NotificationAdminTypeModel();
        return View(viewModel);
    }
    
    [HttpPost]
    public IActionResult Add(Notification notification)
    {
        notification.Status = true;
        notification.Date = DateTime.Now;
        _notificationManager.Add(notification);
        return RedirectToAction("Index");
    }
}