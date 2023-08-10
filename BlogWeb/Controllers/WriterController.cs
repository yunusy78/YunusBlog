using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogWeb.Models;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Controllers;
public class WriterController : Controller
{
    private readonly WriterManager _writerManager;
    private readonly Context _db;
    private readonly UserManager<ApplicationUser> _um;

    public WriterController(Context db, UserManager<ApplicationUser> um )
    {
        _um=um;
        _db = db;
        _writerManager = new WriterManager(new EfWriterRepository(_db));
    }
    
    // GET
    public IActionResult Index()
    {
        
        return View();
    }
    
    public PartialViewResult WriterNav()
    {
        return PartialView();
    }
    
    public PartialViewResult WriterFooter()
    {
        return PartialView();
    }
    
    public IActionResult WriterEditProfile()
    {
        var user = _um.GetUserAsync(User).Result;
        var writer = _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        if (writer != null && writer.Status == true)
        {
            var result = _writerManager.GetById(writer!.Id);
            return View(result);
        }
        else
        {
            return Unauthorized();
        }
        
        
    }
    
    [HttpPost]
    public IActionResult WriterEditProfile(Writer writer, IFormFile? file)
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
                writer.ImageUrl = writer.ImageUrl;
            }
            writer.Status = writer.Status;
            writer.CreatedAt = DateTime.Now;
            _writerManager.Update(writer);
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