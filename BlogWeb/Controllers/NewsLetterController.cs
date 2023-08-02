using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers;

public class NewsLetterController : Controller
{
    private readonly NewsLetterManager _newsLetterManager;
    private readonly Context _db;
    
    public NewsLetterController(Context db)
    {
        _db = db;
        _newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository(_db));
    }
    // GET
    public PartialViewResult SubscribeEmail()
    {
        
        return PartialView();
    }
    
    [HttpPost]
    
    public IActionResult SubscribeEmail(Newsletter newsletter)
    {
        newsletter.Status = true;
        _newsLetterManager.Add(newsletter);
        return RedirectToAction("Index", "Blog");
    }
}