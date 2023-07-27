using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents.Writer;

public class WriterNotification : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}