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
        
        var result = _categoryManager.GetAll();
        return View(result);
    }
    
}