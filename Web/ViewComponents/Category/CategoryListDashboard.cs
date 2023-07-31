using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents.Category;

public class CategoryListDashboard : ViewComponent
{
    CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
    
    public IViewComponentResult Invoke()
    {
        
        var result = _categoryManager.GetAll();
        return View(result);
    }
    
}