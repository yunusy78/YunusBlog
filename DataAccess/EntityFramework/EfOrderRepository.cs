using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Entity.Service;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework;

public class EfOrderRepository : GenericRepository<Order>, IOrderDal
{
    private readonly Context _context;
    
    public EfOrderRepository(Context context) : base(context)
    {
       _context = context; 
    }

    public List<Order> GetListWithUserAndMembership()
    {
        return _context.Orders.Include(x => x.User).Include(x => x.Membership).ToList();
    }
    
    public void UpdateStatus(Guid id, string orderStatus, string? paymentStatus = null)
    {
        var orderFromDb = _context.Orders.FirstOrDefault(u => u.Id == id);
        if (orderFromDb != null)
        {
            orderFromDb.Status = orderStatus;
            if (paymentStatus != null)
            {
                orderFromDb.PaymentStatus = paymentStatus;
            }
        }
        _context.Orders.Update(orderFromDb!);
        _context.SaveChangesAsync();
    }

    public void UpdateStripePaymentId(Guid id, string sessionId, string paymentIntentId)
    {
        var orderFromDb = _context.Orders.FirstOrDefault(u => u.Id == id);
        orderFromDb!.PaymentDate = DateTime.Now;
        orderFromDb.SessionId = sessionId;
        orderFromDb.PaymentIntentId = paymentIntentId;
        orderFromDb.PaymentStatus = PaymentService.PaymentStatusApproved;
        orderFromDb.Status = StatusService.Approved;
        _context.SaveChangesAsync();
    }

    public void UpdateStripeSessionId(Guid id, string sessionId)
    {
        var order = _context.Orders.FirstOrDefault(u => u.Id == id);
        order!.PaymentDate = DateTime.Now;
        order.SessionId = sessionId;
        order.PaymentIntentId=sessionId;
        _context.SaveChangesAsync();
    }

    public List<Order> GetListWithUserAndMembershipWithId(Guid id)
    {
        return _context.Orders.Include(x => x.User).Include(x => x.Membership).Where(x => x.Id == id).ToList();
    }
}