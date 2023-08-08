using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class MessageController : Controller
{
    private readonly Context _db;
    private readonly MessageManager _messageManager;
    private readonly UserManager<ApplicationUser> _um;

    public MessageController(Context db, UserManager<ApplicationUser> um)
    {
        _um=um;
        _db = db;
        _messageManager = new MessageManager(new EfMessageRepository(_db));
    }
    
    // GET
    public IActionResult Inbox()
    {
        var user =  _um.GetUserAsync(User).Result;
        var writer= _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        var result = _messageManager.GetInboxListByWriter(writer!.Id);
        int count = result.Count;
        ViewBag.CountIn = count;
        return View(result);
    }
    
    public IActionResult ReadMessage(Guid id)
    {
        var result = _messageManager.GetById(id);
        return View(result);
    }
    
    public IActionResult ComposeMessage()
    {
        var user = _um.GetUserAsync(User).Result;
        var writer = _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        ViewBag.WriterSender2 = writer!.Id;
        if (writer != null && writer.Status == true)
        {
            var writers = _db.Writers.ToList();
            List<SelectListItem> valueStatus = (from x in writers
                select new SelectListItem
                {
                    Text = x.Email,
                    Value = x.Id.ToString()
                }).ToList();
            ViewBag.WriterReceiver2 = valueStatus;
            
            return View();
        }
        else
        {
            return Unauthorized();
        }
    }
    
    
    [HttpPost]
    public IActionResult ComposeMessage(Message2 message)
    
    {
        message.Date=DateTime.Now;
        message.Status = true;
        _messageManager.Add(message);
        return RedirectToAction("SendBox", "Message", new { area = "Admin" });
        
    }
    
    public IActionResult SendBox()
    {
        var user =  _um.GetUserAsync(User).Result;
        var writer= _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        var result = _messageManager.GetSendBoxListByWriter(writer!.Id);
        ViewBag.CountSend = result.Count;

        return View(result);
    }
    
    
}