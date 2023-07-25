using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.ViewComponents;

public class CommentList: ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var result = new List<UserComment>
        {
            new UserComment
            {
                Id = 1,
                UserName = "Ali"
            },
            new UserComment
            {
                Id = 2,
                UserName = "Veli"
            },
            new UserComment
            {
                Id = 3,
                UserName = "Ayşe"
            },
            new UserComment
            {
                Id = 4,
                UserName = "Fatma"
            },
            new UserComment
            {
                Id = 5,
                UserName = "Zeynep"
            },
        };
        return View(result);
    }
}