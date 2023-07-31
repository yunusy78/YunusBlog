using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class MessageController : Controller
{
    MessageManager _messageManager = new MessageManager(new EfMessageRepository());
    // GET
    public IActionResult Inbox()
    {
        var result = _messageManager.GetInboxListByWriter(Guid.Parse("d171e979-2aa9-4b35-be68-08db9147bf84"));
        return View(result);
    }
    
    public IActionResult ReadMessage(Guid id)
    {
        var result = _messageManager.GetById(id);
        return View(result);
    }
   
}