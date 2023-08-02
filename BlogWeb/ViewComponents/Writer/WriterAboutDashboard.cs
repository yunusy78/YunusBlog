using System.Security.Claims;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace Web.ViewComponents.Writer;

public class WriterAboutDashboard : ViewComponent
{
    private readonly WriterManager writerManager;
    private readonly Context _db;
    private readonly UserManager<ApplicationUser> _um;
    
    public WriterAboutDashboard(Context db, UserManager<ApplicationUser> um)
    {
        _db = db;
        _um = um;
        writerManager = new WriterManager(new EfWriterRepository(_db));
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _um.GetUserAsync((ClaimsPrincipal)User);
        var writer = _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        var result = writerManager.GetWriterById(writer!.Id);  
        return View(result);
    }
    
}