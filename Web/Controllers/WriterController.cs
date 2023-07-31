using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class WriterController : Controller
{
    WriterManager _writerManager = new WriterManager(new EfWriterRepository());
    [Authorize]
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Test()
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
        var guidStringValue = "d171e979-2aa9-4b35-be68-08db9147bf84";
        var guidValue = Guid.Parse(guidStringValue);
        var result = _writerManager.GetById(guidValue);
        return View(result);
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
            writer.Status = true;
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
    
    public IActionResult AddWriter()
    {
        return View();
    }
    
    [HttpPost]  
    public IActionResult AddWriter(Writer writer, IFormFile? file)
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