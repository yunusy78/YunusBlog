using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.ViewComponents.Statistic;

public class Statistic2:ViewComponent
{
    private readonly Context _db;
    private readonly OrderManager _orderManager;
    
    public Statistic2(Context db)
    {
        _db = db;
        _orderManager = new OrderManager(new EfOrderRepository(_db));
    }
    
    public IViewComponentResult Invoke()
    {
        var orders = _orderManager.GetAll();
        var totalOrder = orders.Count;
        var totalOrderPrice = orders.Sum(x => x.Price);
        ViewBag.TotalOrder = totalOrder;
        ViewBag.TotalOrderPrice = totalOrderPrice;
        
        return View();
    }

}