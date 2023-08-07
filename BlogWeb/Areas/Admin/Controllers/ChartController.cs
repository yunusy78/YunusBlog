using BlogWeb.Areas.Admin.Models;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class ChartController : Controller
{
    Context _db;
    public ChartController(Context db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult CategoryChart()
    {
        /*List<Category> list = new List<Category>();
        list.Add(new Category(){Name = "Yazilim",Count = 55});
        list.Add(new Category(){Name = "Seyahat",Count = 5});
        list.Add(new Category(){Name = "Teknoloji",Count = 10});
        return Json( new {jsonlist=list});  */
        
        var categoryList = _db.Categories.ToList();
        var jsonCategories = new List<object>();

        foreach (var category in categoryList)
        {
            var blogCount = _db.Blogs.Count(x => x.CategoryId == category.CategoryId);
            var jsonCategory = new
            {
                Name = category.Name,
                Count = blogCount
            };
            jsonCategories.Add(jsonCategory);
        }

        return Json(new { jsonlist = jsonCategories });
        
        
    }
}