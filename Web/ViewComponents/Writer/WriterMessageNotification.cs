using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents.Writer;

public class WriterMessageNotification :ViewComponent
{
    MessageManager _messageManager = new MessageManager(new EfMessageRepository());
    
    public IViewComponentResult Invoke()
    {
        var result = _messageManager.GetInboxListByWriter(Guid.Parse("d171e979-2aa9-4b35-be68-08db9147bf84"));
        return View(result);
    }
    
    
}