/*using Entity.Concrete;
using DataAccess.Concrete;


using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsletterApi : ControllerBase
{
    private readonly Context _db;
    
public NewsletterApi(Context db)
    {
        _db = db;
    }
    
    [HttpGet(Name = "GetNewsletterList")]
    public IActionResult NewsletterList()
    {
        var blogList = _db.Newsletters.ToList();
        return Ok(blogList);

    }
    
    [HttpPost(Name = "AddNewsletter")]
    public IActionResult AddNewsletter(Newsletter newsletter)
    {
        _db.Newsletters.Add(newsletter);
        _db.SaveChanges();
        return Ok(newsletter);
    }
    
    [HttpPut(Name = "EditNewsletter")]
    public IActionResult EditNewsletter(Newsletter newsletter)
    {
        var newsletterToUpdate = _db.Newsletters.Find(newsletter.Id);
        if (newsletterToUpdate == null)
        {
            return NotFound();
        }
        else
        {
            newsletterToUpdate.Email = newsletter.Email;
            newsletterToUpdate.Status = newsletter.Status;
            newsletterToUpdate.CreatedAt = newsletter.CreatedAt;
            _db.Newsletters.Update(newsletterToUpdate);
            _db.SaveChanges();
            return Ok(newsletterToUpdate);
        }
    }
    

    [HttpDelete("{id}", Name = "DeleteNewsletter")]
    public IActionResult DeleteNewsletter(Guid id)
    {
        var newsletterToDelete = _db.Newsletters.Find(id);
        if (newsletterToDelete == null)
        {
            return NotFound();
        }
        else
        {
            _db.Newsletters.Remove(newsletterToDelete);
            _db.SaveChanges();
            return Ok(newsletterToDelete);
        }
    }
    
   
}*/