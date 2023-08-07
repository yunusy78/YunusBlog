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
        if (ModelState.IsValid)
        {
            // Check if the email already exists in the subscription list
            bool isDuplicate = _newsLetterManager.CheckIfEmailExists(newsletter.Email);

            if (isDuplicate)
            {
                // Return a response indicating that the email already exists
                return BadRequest("Email already subscribed to the newsletter.");
            }

            newsletter.Status = true;
            newsletter.CreatedAt = DateTime.Now; 
            _newsLetterManager.Add(newsletter);
            return PartialView();
        }

        return BadRequest(); // Return a bad request status code (400) if the model is not valid
    }
    
    
}