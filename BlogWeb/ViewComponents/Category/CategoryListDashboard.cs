using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.ViewComponents.Category;

public class CategoryListDashboard : ViewComponent
{
    private readonly CategoryManager _categoryManager;
    private readonly Context _db;
    
    public CategoryListDashboard(Context db)
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