using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.ViewComponents.Blog;

public class BlogListDashboard : ViewComponent
{
    
    
    private readonly BlogManager _blogManager;
    private readonly Context _db;
    
   public BlogListDashboard(Context db)
    {
        _db = db;
        _blogManager = new BlogManager(new EfBlogRepository(_db));
    }

    public IViewComponentResult Invoke()
    {
        var values = _blogManager.GetListWithCategory();
        return View(values);
    }
}