using System.ComponentModel.DataAnnotations;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace BlogWeb.Controllers;
[Authorize]
public class RegisterController : Controller
{
    private readonly WriterManager _writerManager;
    private readonly Context _db;
    private readonly UserManager<ApplicationUser> _um;
    
    public RegisterController(Context db, UserManager<ApplicationUser> um)
    {
        _db = db;
        _um = um;
        _writerManager = new WriterManager(new EfWriterRepository(_db));
    }
    
    
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]  
    public IActionResult Index(Writer writer, IFormFile? file)
    {
        WriterValidator validator = new WriterValidator();
        var result = validator.Validate(writer);
        if (result.IsValid)
        {
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/" + newImageName);
                var stream = new FileStream(location, FileMode.Create);
                file.CopyToAsync(stream);
                writer.ImageUrl =@"/ImageFile/"+newImageName;
            }
            else
            {
                writer.ImageUrl = "default.png";
            }
            writer.CreatedAt = DateTime.Now;
            writer.Status = true;
            var user = _um.GetUserAsync(User).Result;
            writer.ApplicationUserId = user.Id;
            _writerManager.Add(writer);
            return RedirectToAction("Index", "Dashboard");
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