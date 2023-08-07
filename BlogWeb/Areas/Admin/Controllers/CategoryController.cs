using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace BlogWeb.Areas.Admin.Controllers;

[Area("Admin")]
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
    public IActionResult List(int page = 1)
    {
        var values = _categoryManager.GetAll().ToPagedList(page,3);
        return View(values);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        
        return View();
    }
    
    
    [HttpPost]
    public IActionResult Add(Category category, IFormFile? file)
    
    {
        category.Status = true;
        category.CreatedAt = DateTime.Now;
        CategoryValidator validator = new CategoryValidator();
        ValidationResult result = validator.Validate(category);
        
        if (result.IsValid)
        {
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/" + newImageName);
                var stream = new FileStream(location, FileMode.Create);
                file.CopyToAsync(stream);
                category.ImageUrl =@"/ImageFile/"+ newImageName;
            }
            else
            {
                category.ImageUrl = "default.png";
            }
            
            
            _categoryManager.Add(category);
            return RedirectToAction("List", "Category");
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
    
    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var category = _categoryManager.GetById(id);
        return View(category);
    }
    
    [HttpPost]
    public IActionResult Edit(Category category, IFormFile? file)
    {
        CategoryValidator validator = new CategoryValidator();
        ValidationResult result = validator.Validate(category);
        
        if (result.IsValid)
        {
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/" + newImageName);
                var stream = new FileStream(location, FileMode.Create);
                file.CopyToAsync(stream);
                category.ImageUrl =@"/ImageFile/"+ newImageName;
            }
            else
            {
                category.ImageUrl = category.ImageUrl;
            }
            
            
            _categoryManager.Update(category);
            return RedirectToAction("List", "Category");
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
    
    public IActionResult Delete(Guid id)
    {
        var result = _categoryManager.GetById(id);
        _categoryManager.Delete(result);
        return RedirectToAction("List", "Category");
    }
    
    
    
    
    
    
}