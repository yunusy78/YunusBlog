using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public PartialViewResult AdminNavBarPartial()
    {
        return PartialView();
    }
}