using Microsoft.AspNetCore.Mvc;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

namespace BlogWeb.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize (Roles = "Admin")]
public class ApplicationUserController : Controller
{
   private readonly UserManager<ApplicationUser> _um;
   private readonly Context _db;
   
    public ApplicationUserController(UserManager<ApplicationUser> um, Context db)
    {
        _um = um;
        _db = db;
    }


    // GET
    public IActionResult Index(int page=1)
    {
         var result = _db.Users.ToList().ToPagedList(page,2);;
        return View(result);
    }
    
    public IActionResult EditProfile()
    {
        var user =  _um.GetUserAsync(User).Result;
        return View(user);
    }
    
    [HttpPost]
    public IActionResult EditProfile(ApplicationUser model, IFormFile? file)
    {
        var user =  _um.GetUserAsync(User).Result;
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.Email = model.Email;
        user.PhoneNumber = model.PhoneNumber;
        user.UserName = model.UserName;
        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/Profile/" + newImageName);
            var stream = new FileStream(location, FileMode.Create);
            file.CopyToAsync(stream);
            user.ImageUrl =@"/ImageFile/Profile/"+ newImageName;
        }
        else
        {
            user.ImageUrl = user.ImageUrl;
        }
        
        var result = _um.UpdateAsync(user).Result;
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View(model);
        }
        
    }
    
    
    
}