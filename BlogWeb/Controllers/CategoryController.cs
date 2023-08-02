using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers;

public class CategoryController : Controller
{
    private readonly CategoryManager _categoryManager;
    private readonly Context _db;
    
    public CategoryController(Context db)
    {
        _db = db;
        _categoryManager = new CategoryManager(new EfCategoryRepository(_db));
    }
    
    // GET
    public IActionResult Index()
    {
        var values = _categoryManager.GetAll();
        return View(values);
    }
}