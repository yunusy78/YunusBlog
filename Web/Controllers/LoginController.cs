using System.Security.Claims;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
   /* public IActionResult Index(Writer writer)
    {
        Context context = new Context();
        var result = context.Writers.FirstOrDefault(x => x.Email == writer.Email && x.Password == writer.Password);
        if (result != null)
        {
            HttpContext.Session.SetString("username", writer.Email);
            return RedirectToAction("Index", "Writer");
        }
        else
        {
            return View();
        }
        
    }*/
   public async Task<IActionResult> Index(Writer writer)
   {
       Context context = new Context();
       var result = context.Writers.FirstOrDefault(x => x.Email == writer.Email && x.Password == writer.Password);
       if (result != null)
       {
           var claims = new List<Claim>
           {
               new Claim(ClaimTypes.Name, writer.Email)
           };
              var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
           return RedirectToAction("Index", "Writer");
       }
       else
       {
           return View();
       }
   }


}