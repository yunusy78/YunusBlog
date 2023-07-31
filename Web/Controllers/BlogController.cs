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
    CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
    
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
        
        var categories = _categoryManager.GetAll();
        List<SelectListItem> valueStatus = (from x in categories
            select new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            }).ToList();
        ViewBag.Categories2 = valueStatus;
        
        return View();
    }
    
    
    [HttpPost]
    public IActionResult AddToBlog(Blog blog, IFormFile? file)
    
    {
        // Code to get the list of categories and populate the ViewBag
        var categories = _categoryManager.GetAll();
        List<SelectListItem> valueStatus = (from x in categories
            select new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            }).ToList();
        ViewBag.Categories2 = valueStatus;
        
        BlogValidator validator = new BlogValidator();
        ValidationResult result = validator.Validate(blog);
        
        if (result.IsValid)
        {
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/" + newImageName);
                var stream = new FileStream(location, FileMode.Create);
                file.CopyToAsync(stream);
                blog.ImageUrl =@"/ImageFile/"+ newImageName;
            }
            else
            {
                blog.ImageUrl = "default.png";
            }
            blog.WriterId = Guid.Parse("fbaf0787-8b6a-4e59-cc1a-08db8de02bfc");
            blog.CreatedAt = DateTime.Now;
            blog.Status = true;
            _blogManager.Add(blog);
            return RedirectToAction("Index", "Blog");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        return View();
        
        
    }
    
    public IActionResult DeleteBlog(Guid id)
    {
        var result = _blogManager.GetById(id);
        _blogManager.Delete(result);
        return RedirectToAction("BlogListByWriter", "Blog");
    }
    
    public IActionResult UpdateBlog(Guid id)
    {
        
        var categories = _categoryManager.GetAll();
        var result = _blogManager.GetById(id);
        List<SelectListItem> valueStatus = (from x in categories
            select new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            }).ToList();
        ViewBag.Categories = valueStatus;
        return View(result);
    }
    
    [HttpPost]
    public IActionResult UpdateBlog(Blog blog , IFormFile? file)
    {
        // Code to get the list of categories and populate the ViewBag
        var categories = _categoryManager.GetAll();
        List<SelectListItem> valueStatus = (from x in categories
            select new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            }).ToList();
        ViewBag.Categories = valueStatus;
        
        BlogValidator validator = new BlogValidator();
        ValidationResult result = validator.Validate(blog);
        
        if (result.IsValid)
        {
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/" + newImageName);
                var stream = new FileStream(location, FileMode.Create);
                file.CopyToAsync(stream);
                blog.ImageUrl =@"/ImageFile/"+ newImageName;
            }
            else
            {
                blog.ImageUrl = blog.ImageUrl;
            }
            
            blog.WriterId = Guid.Parse("fbaf0787-8b6a-4e59-cc1a-08db8de02bfc");
            blog.CreatedAt = DateTime.Now;
            _blogManager.Update(blog);
            return RedirectToAction("Index", "Blog");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        return View();
        
    }
  
}