using System.Diagnostics;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers;
[Area("Admin")]

[Authorize (Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _um;
    private readonly Context _db;
    private readonly MessageManager _messageManager;
    
    public AdminController(UserManager<ApplicationUser> um, Context db)
    {
        _messageManager = new MessageManager(new EfMessageRepository(_db));
        _um = um;
        _db = db;
    }

    // GET
    public IActionResult Index()
    {
        var user =  _um.GetUserAsync(User).Result;
        var writer= _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        return View();
    }
    
    public PartialViewResult AdminNavBarPartial()
    {
        
        return PartialView();
    }
}