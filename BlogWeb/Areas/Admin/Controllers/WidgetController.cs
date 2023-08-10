using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers;
[Authorize (Roles = "Admin")]
[Area("Admin")]
public class WidgetController : Controller
{
    private readonly Context _db;
    private readonly UserManager<ApplicationUser> _um;
    public WidgetController(Context db , UserManager<ApplicationUser> um)
    {
        _db = db;
        _um = um;
    }
    // GET
    public IActionResult Index()
    {
        var users = _db.Users.Count();
        var posts = _db.Blogs.Count();
        var writers = _db.Writers.Count();
        var comments = _db.Comments.Count();
        var categories = _db.Categories.Count();
        var notifications = _db.Notifications.Count();
        var messages = _db.Messages.Count();
        var likes= _db.Comments.Count(x => x.BlogRating >= 3);
        var newsletters = _db.Newsletters.Count();
        ViewBag.Users = users;
        ViewBag.Posts = posts;
        ViewBag.Comments = comments;
        ViewBag.Categories = categories;
        ViewBag.Notifications = notifications;
        ViewBag.Messages = messages;
        ViewBag.Likes = likes;
        ViewBag.Writers = writers;
        ViewBag.Newsletters = newsletters;
        return View();
    }
}