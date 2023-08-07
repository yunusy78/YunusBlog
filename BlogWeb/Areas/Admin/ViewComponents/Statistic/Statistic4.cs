using System.Security.Claims;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.ViewComponents.Statistic;

public class Statistic4:ViewComponent
{
    private readonly Context _db;
    private readonly UserManager<ApplicationUser> _um;


    public Statistic4(Context db, UserManager<ApplicationUser> um)
    {
        _db = db;
        _um = um;
    }
    
    public IViewComponentResult Invoke()
    {
        var user = _um.GetUserAsync(HttpContext.User).Result;
        if (user != null)
        {
            var roles = _um.GetRolesAsync(user).Result;
            if (roles.Contains("Admin"))
            {
                ViewBag.Name = user.FirstName + " " + user.LastName;
                ViewBag.image = user.ImageUrl!;
                ViewBag.Email = user.Email;
            }
            else
            {
                return View();
            }
        }
        
        
        
        return View();
    }
    
}