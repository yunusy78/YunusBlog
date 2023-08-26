using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BlogWeb.Areas.Admin.Controllers;
[Authorize (Roles = "Admin")]
[Area("Admin")]
public class OrderController : Controller
{
    private readonly OrderManager _orderManager;
    private readonly Context _context;
    
    public OrderController( Context context)
    {
        _context = context;
        _orderManager = new OrderManager(new EfOrderRepository(_context));
    }
    
    // GET
    public IActionResult Index(int page = 1)
    {
        var orders = _orderManager.GetListWithUserAndMembership().ToPagedList(page ,3);
        return View(orders);
    }
    
    public IActionResult Delete(Guid id)
    {
        var order = _orderManager.GetById(id);
        _orderManager.Delete(order);
        return RedirectToAction("Index");
        
    }

    public IActionResult Update(Guid id)
    {
        var order = _orderManager.GetById(id);
        return View(order);
    }
    
    
    [HttpPost]
    public IActionResult Update(Order model)
    {
        _orderManager.Update(model);
        return RedirectToAction("Index");
    }
    
    
    
    
    
    
}