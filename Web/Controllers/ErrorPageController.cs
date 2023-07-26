using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ErrorPageController : Controller
{
    // GET
    public IActionResult Error1(int code)
    {
        return View();
    }
    
}