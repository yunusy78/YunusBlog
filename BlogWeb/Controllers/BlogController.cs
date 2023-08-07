using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWeb.Controllers;

public class BlogController : Controller
{
    private readonly BlogManager _blogManager;
    private readonly CategoryManager _categoryManager;
    private readonly Context _db;
    private readonly UserManager<ApplicationUser> _um;

    public BlogController(Context db, UserManager<ApplicationUser> um)
    {
        _db = db;
        _um = um;
        _blogManager = new BlogManager(new EfBlogRepository(_db));
        _categoryManager = new CategoryManager(new EfCategoryRepository(_db));
    }
    

    // GET
    public IActionResult Index()
    {
        var result = _blogManager.GetListWithCategory();
        return View(result);
    }
    
    public IActionResult Details(Guid id)
    {
        ViewBag.id = id;
        TempData["MyValue"] = id;
        var result = _blogManager.GetBlogById(id);
        return View(result);
    }
    
    
    [Authorize(Roles = RoleService.Role_User_Writer)]
    public IActionResult BlogListByWriter()
    {
        var user =  _um.GetUserAsync(User).Result;
        var writer = _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        var result = _blogManager.GetBlogListWithCategory(writer!.Id);
        if(result.Count==0)
        return RedirectToAction("AddToBlog");
        else
        {
            return View(result);
        }
        
    }
    
    
    [Authorize(Roles = RoleService.Role_User_Writer)]
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
            var user =  _um.GetUserAsync(User).Result;
            var writer2= _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
            blog.WriterId = writer2!.Id;
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
    
    [Authorize(Roles = RoleService.Role_User_Writer)]
    public IActionResult DeleteBlog(Guid id)
    {
        var user =  _um.GetUserAsync(User).Result;
        var writer= _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        
        var result = _blogManager.GetById(id);
        if (result.WriterId != writer!.Id)
        {
            
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        _blogManager.Delete(result);
        return RedirectToAction("BlogListByWriter", "Blog");
    }
    [Authorize(Roles = RoleService.Role_User_Writer)]
    public IActionResult UpdateBlog(Guid id)
    {
        
        var user =  _um.GetUserAsync(User).Result;
        var writer= _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        
        var categories = _categoryManager.GetAll();
        var result = _blogManager.GetById(id);
        if (result.WriterId != writer!.Id)
        {
            
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        
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
        var user =  _um.GetUserAsync(User).Result;
        var writer= _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        
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
            
            blog.CreatedAt = DateTime.Now;
            _blogManager.Update(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
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