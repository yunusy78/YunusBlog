using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.ViewComponents.Statistic;

public class Statistic2:ViewComponent
{
    private readonly Context _db;
    
    public Statistic2(Context db)
    {
        _db = db;
    }
    
    public IViewComponentResult Invoke()
    {
        
        return View();
    }

}