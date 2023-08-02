using System.Security.Claims;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.ViewComponents.Blog;

public class WriterLastBlog : ViewComponent
{
    private readonly BlogManager _blogManager;
    private readonly Context _db;
    private readonly UserManager<ApplicationUser> _um;
    
    public WriterLastBlog(Context db, UserManager<ApplicationUser> um)
    {
        _um = um;
        _db = db;
        _blogManager = new BlogManager(new EfBlogRepository(_db));
    }
    
    public IViewComponentResult Invoke()
    {
        if (TempData.ContainsKey("MyValue") && TempData["MyValue"] is Guid myValue)
        {
            
            Guid blogId = myValue;
            var blog = _db.Blogs.FirstOrDefault(x => x.Id == blogId);
            var writer = _db.Writers.FirstOrDefault(x => x.Id == blog!.WriterId);
            var result = _blogManager.GetListByWriterId(writer!.Id);
            return View(result);
        }

        return View();

    }
    
}