using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.ViewComponents.Comments;

public class CommentListByBlog: ViewComponent
{
    
    private readonly CommentManager _commentManager;
    private readonly Context _db;
    
    
    public CommentListByBlog(Context db)
    {
        _db = db;
        _commentManager = new CommentManager(new EfCommentRepository(_db));
    }
    public IViewComponentResult Invoke(Guid id)
    {
        var result = _commentManager.GetAll2(id);
        return View(result);
    }
}