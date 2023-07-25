using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class CategoryController : Controller
{
    CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
    // GET
    public IActionResult Index()
    {
        var values = _categoryManager.GetAll();
        return View(values);
    }
}