using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class WidgetController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}