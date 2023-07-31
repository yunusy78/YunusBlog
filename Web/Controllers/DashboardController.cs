using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        Context context = new Context();
        ViewBag.BlogCount = context.Blogs.Count().ToString();
        var guidStringValue = "fbaf0787-8b6a-4e59-cc1a-08db8de02bfc";
        var guidValue = Guid.Parse(guidStringValue);
        ViewBag.BlogWriterCount = context.Blogs.Count(x => x.WriterId ==guidValue).ToString();
        ViewBag.CategoryCount = context.Categories.Count().ToString();
        return View();
    }
}