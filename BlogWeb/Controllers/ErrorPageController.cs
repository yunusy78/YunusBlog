using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers;

public class ErrorPageController : Controller
{
    // GET
    public IActionResult Error1(int code)
    {
        return View();
    }
    
    public IActionResult ErrorPageDublicate()
    {
        return View();
    }
    
}