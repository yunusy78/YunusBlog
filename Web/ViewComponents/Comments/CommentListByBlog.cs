using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents.Comments;

public class CommentListByBlog: ViewComponent
{
    CommentManager _commentManager = new CommentManager(new EfCommentRepository());
    public IViewComponentResult Invoke(Guid id)
    {
        var result = _commentManager.GetAll2(id);
        return View(result);
    }
}