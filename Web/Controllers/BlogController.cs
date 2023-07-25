using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class BlogController : Controller
{
    BlogManager _blogManager = new BlogManager(new EfBlogRepository());
    // GET
    public IActionResult Index()
    {
        var result = _blogManager.GetListWithCategory();
        return View(result);
    }
    
    public IActionResult Details(Guid id)
    {
        var result = _blogManager.GetBlogById(id);
        return View(result);
    }
}