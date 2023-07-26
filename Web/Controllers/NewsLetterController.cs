using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class NewsLetterController : Controller
{
    NewsLetterManager _newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository());
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