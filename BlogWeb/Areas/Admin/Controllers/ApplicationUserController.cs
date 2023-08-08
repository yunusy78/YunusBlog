using Microsoft.AspNetCore.Mvc;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Entity.Concrete;
using X.PagedList;

namespace BlogWeb.Areas.Admin.Controllers;
[Area("Admin")]
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
    
     
    
}