using System.Xml.Linq;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.ViewComponents.Statistic;

public class Statistic1:ViewComponent
{
    private readonly BlogManager _blogManager;
    private readonly Context _db;
    
    public Statistic1(Context db)
    {
        _db = db;
        _blogManager = new BlogManager(new EfBlogRepository(_db));
    }
    
    public IViewComponentResult Invoke()
    {
        
        ViewBag.TotalBlog = _blogManager.GetAll().Count;
        ViewBag.TotalMessage = _db.Contacts.Count();
        ViewBag.Comments = _db.Comments.Count();
        string apiKey = "45217de5e5d66ccd52ffab48a62f5018";
        string connectionString = "https://api.openweathermap.org/data/2.5/weather?q=Oslo&mode=xml&lang=metric&appid=" + apiKey;
        
        XDocument document = XDocument.Load(connectionString);
        string kelvinString = document.Descendants("temperature")!.ElementAt(0)!.Attribute("value")!.Value;
        double kelvin = double.Parse(kelvinString);
        double celsius = kelvin - 273.15;
        ViewBag.Temperature = celsius.ToString("0.0");
        return View();
    }
}