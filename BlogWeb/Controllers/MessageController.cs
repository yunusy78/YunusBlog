using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
    
    
 
    
    public IActionResult SendMessage()
    {
        var user = _um.GetUserAsync(User).Result;
        var writer = _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        
        if (writer != null && writer.Status == true)
        {
            var writers = _db.Writers.ToList();
            List<SelectListItem> valueStatus = (from x in writers
                select new SelectListItem
                {
                    Text = x.Email,
                    Value = x.Id.ToString()
                }).ToList();
            ViewBag.WriterReceiver = valueStatus;
            ViewBag.WriterSender = writer.Id;
            return View();
        }
        else
        {
            return Unauthorized();
        }
    }
    
    
    [HttpPost]
    public IActionResult SendMessage(Message2 message)
    
    {
        message.Date=DateTime.Now;
        message.Status = true;
        _messageManager.Add(message);
        return RedirectToAction("BlogListByWriter", "Blog");
        
    }
    
public IActionResult SendBox()
    {
        var user =  _um.GetUserAsync(User).Result;
        var writer= _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        var result = _messageManager.GetSendBoxListByWriter(writer!.Id);
        return View(result);
    }


}