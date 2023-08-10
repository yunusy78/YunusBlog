using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize (Roles = "Admin")]
public class CommentController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly CommentManager _commentManager;
    private readonly Context _db;
    
    public CommentController(Context db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
        _commentManager = new CommentManager(new EfCommentRepository(_db));
    }
    
    
    // GET
    public IActionResult Index()
    {
        var result = _commentManager.GetListWithBlog();
        return View(result);
    }
    
    public IActionResult Edit(Guid id)
    {
        var result = _commentManager.GetById(id);
        return View(result);
    }
    
    [HttpPost]
    public IActionResult Edit(Comment comment)
    {
        _commentManager.Update(comment);
        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(Guid id)
    {
        var result = _commentManager.GetById(id);
        _commentManager.Delete(result);
        return RedirectToAction("Index");
    }
    
}