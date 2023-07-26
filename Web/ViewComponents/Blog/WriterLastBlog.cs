using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents.Blog;

public class WriterLastBlog : ViewComponent
{
    BlogManager _blogManager = new(new EfBlogRepository());
    
    public IViewComponentResult Invoke()
    {
        var guidStringValue = "cbe2caeb-aa87-43bb-4a3e-08db8dd1d2b5";
        var guidValue = Guid.Parse(guidStringValue);
        var result = _blogManager.GetListByWriterId(guidValue);
        return View(result);
    }
    
}