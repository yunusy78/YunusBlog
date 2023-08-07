using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}