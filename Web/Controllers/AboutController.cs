using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class AboutController : Controller
{
    AboutManager _aboutManager = new AboutManager(new EfAboutRepository());
    // GET
    public IActionResult Index()
    {
        var aboutValues = _aboutManager.GetAll();
        return View(aboutValues);
    }

    public PartialViewResult SosialMediaAbout()
    {
        
        return PartialView();
    }
}