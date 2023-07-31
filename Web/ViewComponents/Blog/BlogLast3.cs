using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.ViewComponents.Blog;

public class BlogLast3:ViewComponent
{
    BlogManager _blogManager = new(new EfBlogRepository());
    
    public IViewComponentResult Invoke()
    {
        
        var result = _blogManager.GetLastThreeBlog();
        return View(result);
    }
    
}