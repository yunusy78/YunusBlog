using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class NotificationController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}