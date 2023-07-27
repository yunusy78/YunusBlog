using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents.Writer;

public class WriterMessageNotification :ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}