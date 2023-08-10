using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize (Roles = "Admin")]
public class BlogController : Controller
{
    private readonly BlogManager _blogManager;
    private readonly Context _db;
    
    public BlogController(Context db)
    {
        _db = db;
        _blogManager = new BlogManager(new EfBlogRepository(_db));
    }
    
    // GET
    public IActionResult Index()
    {
        var result = _blogManager.GetListWithCategory();
        return View(result);
    }
}