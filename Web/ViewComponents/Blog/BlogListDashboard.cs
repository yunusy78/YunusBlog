using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents.Blog;

public class BlogListDashboard : ViewComponent
{
    BlogManager _blogManager = new BlogManager(new EfBlogRepository());
    public IViewComponentResult Invoke()
    {
        var values = _blogManager.GetListWithCategory();
        return View(values);
    }
}