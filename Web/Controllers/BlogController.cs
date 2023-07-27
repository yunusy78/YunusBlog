using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        ViewBag.id = id;
        var result = _blogManager.GetBlogById(id);
        return View(result);
    }
    
    public IActionResult BlogListByWriter()
    {
        var guidStringValue = "fbaf0787-8b6a-4e59-cc1a-08db8de02bfc";
        var guidValue = Guid.Parse(guidStringValue);
        var result = _blogManager.GetBlogListWithCategory(guidValue);
        return View(result);
    }
    
    public IActionResult AddToBlog()
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        var categories = _categoryManager.GetAll();
        ViewBag.Categories = categories;
        /*List<SelectListItem> valueStatus = (from x in categories
            select new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            }).ToList();*/


        return View();
    }
    
    
    [HttpPost]
    public IActionResult AddToBlog(Blog blog)
    
    {
        
        blog.CreatedAt = DateTime.Now;
        blog.Status = true;
        blog.ImageUrl = "deneme.jpg";
        blog.WriterId = Guid.Parse("fbaf0787-8b6a-4e59-cc1a-08db8de02bfc");
        BlogValidator validator = new BlogValidator();
       ValidationResult result = validator.Validate(blog);
        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View();
        }
        else
        {
            
            
            _blogManager.Add(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
            
        }
        
    }
  
}