using Business.Concrete;
using DataAccess.EntityFramework;
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
    
    public PartialViewResult CommentListByBlog(Guid id)
    {
        var result = _commentManager.GetAll(id);
        return PartialView(result);

    }
}