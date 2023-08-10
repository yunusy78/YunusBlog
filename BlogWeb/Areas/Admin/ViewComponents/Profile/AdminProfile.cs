using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.ViewComponents.Profile;

public class AdminProfile : ViewComponent
{
    private readonly Context _db;
    private readonly UserManager<ApplicationUser> _um;
    
    public AdminProfile(Context db, UserManager<ApplicationUser> um)
    {
        _db = db;
        _um = um;
    }
    
    public IViewComponentResult Invoke()
    {
        var user =  _um.GetUserAsync(HttpContext.User).Result;
        ViewBag.Name = user.FirstName + " " + user.LastName;
        ViewBag.Email = user.Email;
        ViewBag.Image = user.ImageUrl!;
        return View();
    }
    
}