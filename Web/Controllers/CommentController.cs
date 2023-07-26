using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class CommentController : Controller
{
    CommentManager _commentManager = new CommentManager(new EfCommentRepository());
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public PartialViewResult PartialAddComment()
    {
        return PartialView();

    }
    
    [HttpPost]
    public IActionResult PartialAddComment(Comment comment)
    {
     
        comment.CreatedAt=DateTime.Parse(DateTime.Now.ToShortDateString());
        comment.Status = true;
        comment.BlogId = Guid.Parse("cdf15c7e-9562-47ed-aef7-e95f31e42182");
        _commentManager.Add(comment);
        return RedirectToAction("Index", "Blog");

    }
    
    public PartialViewResult CommentListByBlog(Guid id)
    {
        var result = _commentManager.GetAll(id);
        return PartialView(result);

    }
}