using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class WriterController : Controller
{
    [Authorize]
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Test()
    {
        return View();
    }
    
    public PartialViewResult WriterNav()
    {
        return PartialView();
    }
    
    public PartialViewResult WriterFooter()
    {
        return PartialView();
    }
    
    
}