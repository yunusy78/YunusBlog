using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ContactController : Controller
{
    ContactManager _contactManager = new ContactManager(new EfContactRepository());
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(Contact contact)
    {
        contact.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
        contact.Status = true;
        _contactManager.Add(contact);
        return RedirectToAction("Index","Blog");
    }
    
    
}