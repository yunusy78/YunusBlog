using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.ViewComponents.Blog;

public class RecentBlog:ViewComponent
{
    private readonly Context _context;
    
    private readonly BlogManager _blogManager;
    
    public RecentBlog(Context context)
    {
        _context = context;
        _blogManager = new BlogManager(new EfBlogRepository(context));
    }
    
    
    public IViewComponentResult Invoke()
    {
        var values = _context.Blogs.OrderByDescending(x => x.CreatedAt).Take(1).ToList();
        
        return View(values);
    }
    
    
}