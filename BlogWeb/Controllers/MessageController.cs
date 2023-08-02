using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers;

public class MessageController : Controller
{
    private readonly MessageManager _messageManager;
    private readonly Context _db;
    private readonly UserManager<ApplicationUser> _um;

    public MessageController(Context db , UserManager<ApplicationUser> um)
    {
        _db = db;
        _um = um;
        _messageManager = new MessageManager(new EfMessageRepository(_db));
    }
    
    // GET
    public IActionResult Inbox()
    {
        var user =  _um.GetUserAsync(User).Result;
        var writer= _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        var result = _messageManager.GetInboxListByWriter(writer!.Id);
        return View(result);
    }
    
    public IActionResult ReadMessage(Guid id)
    {
        var result = _messageManager.GetById(id);
        return View(result);
    }
   
}