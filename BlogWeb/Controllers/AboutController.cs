using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers;

public class AboutController : Controller
{
    private readonly AboutManager _aboutManager;
    private readonly Context _db;

    public AboutController(Context db)
    {
        _db = db;
        _aboutManager = new AboutManager(new EfAboutRepository(_db));
    }
    
    
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