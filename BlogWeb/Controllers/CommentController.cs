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
    
    
    public PartialViewResult PartialAddComment()
    {
        return PartialView();

    }
    
    [Authorize]
    [HttpPost]
    public IActionResult PartialAddComment(Comment comment)
    {
     
        comment.CreatedAt=DateTime.Parse(DateTime.Now.ToShortDateString());
        comment.Status = true;
        comment.BlogId = Guid.Parse("f3b340d4-8903-4523-8a4f-e661c5f02e3d");
        _commentManager.Add(comment);
        return RedirectToAction("Index", "Blog");

    }
    
    public PartialViewResult CommentListByBlog(Guid id)
    {
        var result = _commentManager.GetAll2(id);
        return PartialView(result);

    }
}