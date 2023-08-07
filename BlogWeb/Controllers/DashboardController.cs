using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers;


public class DashboardController : Controller
{
    
    private readonly Context _db;
    private readonly UserManager<ApplicationUser> _um;
    
    
    
    public DashboardController(Context db , UserManager<ApplicationUser> um)
    {
        _db = db;
        _um = um;
        
    }
    
    // GET
    public IActionResult Index()
    {
        ViewBag.BlogCount = _db.Blogs.Count().ToString();
        var user =  _um.GetUserAsync(User).Result;
        var writer= _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        if (writer != null && writer.Status == true)
        {
            ViewBag.BlogWriterCount = _db.Blogs.Count(x => x.WriterId ==writer!.Id).ToString();
            ViewBag.CategoryCount = _db.Categories.Count().ToString();
            return View();
        }
        else
        {
            return Unauthorized();
        }
        
    }
}