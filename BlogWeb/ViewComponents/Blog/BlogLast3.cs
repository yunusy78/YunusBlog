using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.ViewComponents.Blog;

public class BlogLast3:ViewComponent
{
    private readonly BlogManager _blogManager;
    private readonly Context _db;
    
    public BlogLast3(Context db)
    {
        _db = db;
        _blogManager = new BlogManager(new EfBlogRepository(_db));
    }
    
    
    public IViewComponentResult Invoke()
    {
        
        var result = _blogManager.GetLastThreeBlog();
        return View(result);
    }
    
}