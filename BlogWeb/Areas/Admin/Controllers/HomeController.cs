using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers;
[Authorize (Roles = "Admin")]
public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}