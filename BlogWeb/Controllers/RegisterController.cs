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
    private readonly MessageManager _messageManager;
    
    public RegisterController(Context db, UserManager<ApplicationUser> um)
    {
        _db = db;
        _um = um;
        _writerManager = new WriterManager(new EfWriterRepository(_db));
        _messageManager = new MessageManager(new EfMessageRepository(_db));
    }
    
    
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]  
    public async Task<IActionResult> Index(Writer writer, IFormFile? file)
    {
        WriterValidator validator = new WriterValidator();
        var result = validator.Validate(writer);
        if (result.IsValid)
        {
            bool isDuplicate = _writerManager.CheckIfEmailExists(writer.Email);

            if (isDuplicate)
            {
                // Return a response indicating that the email already exists
                return RedirectToAction("ErrorPageDublicate", "ErrorPage");
            }
            
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/Writer/" + newImageName);
                var stream = new FileStream(location, FileMode.Create);
                file.CopyToAsync(stream);
                writer.ImageUrl =@"/ImageFile/Writer/"+newImageName;
            }
            else
            {
                writer.ImageUrl = "default.png";
            }
            writer.CreatedAt = DateTime.Now;
            writer.Status = false;
            var user = _um.GetUserAsync(User).Result;
            //_um.AddToRoleAsync(user, "Writer").Wait();
            writer.ApplicationUserId = user.Id;
            _writerManager.Add(writer);
            await _db.SaveChangesAsync();
            return RedirectToAction("Success", "Register");
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
    
    
    public async Task<IActionResult> Success()
    {
        var user = _um.GetUserAsync(User).Result;
        var writer2 = _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        Message2 message2 = new Message2();
        message2.SenderId = writer2!.Id;
        message2.ReceiverId = Guid.Parse("3252c6ce-847d-481a-18f0-08db96cd347a");
        message2.Subject = "New Writer Registration";
        message2.Content = $"{writer2.Name} has registered to the system.";
        message2.Date = DateTime.Now;
        message2.Status = true;
        _messageManager.Add(message2);
        return View();
    }
    
    

}