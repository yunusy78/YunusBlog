using System.ComponentModel.DataAnnotations;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Web.Controllers;

public class RegisterController : Controller
{
    WriterManager _writerManager = new WriterManager(new EfWriterRepository());
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    
    [HttpPost]
    public IActionResult Index(Writer writer)
    {
        WriterValidator validator = new WriterValidator();
        ValidationResult result = validator.Validate(writer);
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
            writer.Status = true;
            writer.About = "Deneme";
            writer.ImageUrl = "deneme.jpg";
            _writerManager.Add(writer);
            return RedirectToAction("Index", "Blog");
        }
        
    }

}