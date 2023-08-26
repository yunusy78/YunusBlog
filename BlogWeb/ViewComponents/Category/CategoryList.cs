using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.ViewComponents.Category;

public class CategoryList: ViewComponent
{
    private readonly CategoryManager _categoryManager;
    private readonly Context _db;
    
    public CategoryList(Context db)
    {
        _db = db;
        _categoryManager = new CategoryManager(new EfCategoryRepository(_db));
    }
    
    public IViewComponentResult Invoke()
    {
        var categoryList = _db.Categories.ToList();
        var result = new List<object>();
        foreach (var category in categoryList)
        {
            var blogCount = _db.Blogs.Count(x => x.CategoryId == category.CategoryId);
            var item = new
            {
                Name = category.Name,
                Count = blogCount
            };
            
            result.Add(item);
        }
        
        return View(result);
    }
    
}