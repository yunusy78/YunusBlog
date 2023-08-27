using System.Data;
using System.Globalization;
using BlogWeb.Areas.Admin.Models;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize (Roles = "Admin")]
public class ChartController : Controller
{
    Context _db;
    public ChartController(Context db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult CategoryChart()
    {
        /*List<Category> list = new List<Category>();
        list.Add(new Category(){Name = "Yazilim",Count = 55});
        list.Add(new Category(){Name = "Seyahat",Count = 5});
        list.Add(new Category(){Name = "Teknoloji",Count = 10});
        return Json( new {jsonlist=list});  */
        
        var categoryList = _db.Categories.ToList();
        var jsonCategories = new List<object>();

        foreach (var category in categoryList)
        {
            var blogCount = _db.Blogs.Count(x => x.CategoryId == category.CategoryId);
            var jsonCategory = new
            {
                Name = category.Name,
                Count = blogCount
            };
            jsonCategories.Add(jsonCategory);
        }

        return Json(new { jsonlist = jsonCategories });
        
        
    }
    
    public IActionResult OrderChart()
    {
       
        var membershipList = _db.Memberships.ToList();
        var jsonMembership = new List<object>();

        foreach (var membership in membershipList)
        {
            var orderCount = _db.Orders.Count(x => x.MembershipId == membership.Id);
            var jsonOrderCount = new
            {
                Name = membership.Name,
                Count = orderCount
            };
            jsonMembership.Add(jsonOrderCount);
        }
        return Json(new { jsonlist = jsonMembership });
    }
    
    public IActionResult UserChart()
    {
        var userList = _db.Writers.ToList();
        var jsonUsers = new List<object>();

        foreach (var user in userList)
        {
            var blogCount = _db.Blogs.Count(x => x.WriterId == user.Id);
            var jsonUser = new
            {
                Name = user.Name,
                Count = blogCount
            };
            jsonUsers.Add(jsonUser);
        }

        return Json(new { jsonlist = jsonUsers });
    }
    
    public IActionResult CommentChart()
    {
        var commentList = _db.Blogs.ToList();
        var jsonComments = new List<object>();

        foreach (var comment in commentList)
        {
            var blogCount = _db.Comments.Where(x => x.BlogRating >= 3).Count(x => x.BlogId == comment.Id);
            var jsonComment = new
            {
                Name = comment.Title,
                Count = blogCount
            };
            jsonComments.Add(jsonComment);
        }

        return Json(new { jsonlist = jsonComments });
    }
    
    
    public IActionResult RevenueChart()
    {
        var revenueByMonth = _db.Orders
            .AsEnumerable()
            .GroupBy(x => x.OrderDate.Month)
            .Select(group => new
            {
                Month = group.Key.ToString(),
                Revenue = group.Sum(x => x.Price)
            })
            .OrderBy(x => x.Month)
            .ToList();
        
        var months = revenueByMonth.Select(x => x.Month).ToArray();
        var revenues = revenueByMonth.Select(x => x.Revenue).ToArray();

        return Json(new { Months = months, Revenues = revenues });
    }



    
    

    
    
    
   
}