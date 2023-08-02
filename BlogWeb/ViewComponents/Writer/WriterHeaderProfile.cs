using System.Security.Claims;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Web.ViewComponents.Writer;

public class WriterHeaderProfile: ViewComponent
{
    private readonly MessageManager _messageManager;
    private readonly Context _db;
    private readonly UserManager<ApplicationUser> _um;

    public WriterHeaderProfile(Context db , UserManager<ApplicationUser> um)
    {
        _um=um;
        _db = db;
        _messageManager = new MessageManager(new EfMessageRepository(_db));
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _um.GetUserAsync((ClaimsPrincipal)User);
        var result = _db.Writers.FirstOrDefault(x => x.ApplicationUserId == user.Id);
        return View(result);
    }
}