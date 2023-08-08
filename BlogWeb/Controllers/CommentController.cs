using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers;

public class CommentController : Controller
{
    private readonly CommentManager _commentManager;
    private readonly Context _db;
    
    public CommentController(Context db)
    {
        _db = db;
        _commentManager = new CommentManager(new EfCommentRepository(_db));
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Add()
    {
        return View();

    }
    
    [Authorize]
    [HttpPost]
    public IActionResult Add(Comment comment)
    {
     
        comment.CreatedAt=DateTime.Now;
        comment.Status = true;
        _commentManager.Add(comment);
        return RedirectToAction("Index", "Blog");

    }
    
    
    
    public PartialViewResult PartialAddComment()
    {
        return PartialView();

    }
    
    [Authorize]
    [HttpPost]
    public IActionResult PartialAddComment(Comment comment)
    {
     
        comment.CreatedAt=DateTime.Now;
        comment.Status = true;
        _commentManager.Add(comment);
        return RedirectToAction("Index", "Blog");

    }
    
    public PartialViewResult CommentListByBlog(Guid id)
    {
        var result = _commentManager.GetAll2(id);
        return PartialView(result);

    }
}