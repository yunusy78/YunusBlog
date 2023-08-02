using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers;

public class ContactController : Controller
{
    
    private readonly ContactManager _contactManager;
    private readonly Context _db;
    
    public ContactController(Context db)
    {
        _db = db;
        _contactManager = new ContactManager(new EfContactRepository(_db));
    }
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