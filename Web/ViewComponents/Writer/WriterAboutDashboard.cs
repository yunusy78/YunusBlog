using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents.Writer;

public class WriterAboutDashboard : ViewComponent
{
    WriterManager writerManager = new WriterManager(new EfWriterRepository());
    public IViewComponentResult Invoke()
    {
        var guidStringValue = "cbe2caeb-aa87-43bb-4a3e-08db8dd1d2b5";
        var guidValue = Guid.Parse(guidStringValue);
        var result = writerManager.GetWriterById(guidValue);  
        return View(result);
    }
    
}