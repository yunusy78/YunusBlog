using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class OrderManager :IOrderService
{
    IOrderDal _orderDal;
    
    public OrderManager(IOrderDal orderDal)
    {
        _orderDal = orderDal;
    }
    public void Add(Order entity)
    {
        _orderDal.Add(entity);
    }

    public void Update(Order entity)
    {
       _orderDal.Update(entity);
    }

    public void Delete(Order entity)
    {
        _orderDal.Delete(entity);
    }

    public List<Order> GetAll()
    {
        return _orderDal.GetList();
    }

    public Order GetById(Guid id)
    {
        return _orderDal.GetById(id);
    }

    public List<Order> GetListWithUserAndMembership()
    {
        return _orderDal.GetListWithUserAndMembership();
    }

    public void UpdateStatus(Guid id, string orderStatus, string? paymentStatus = null)
    {
        _orderDal.UpdateStatus(id, orderStatus, paymentStatus);
    }

    public void UpdateStripePaymentId(Guid id, string sessionId, string paymentIntentId)
    {
        _orderDal.UpdateStripePaymentId(id, sessionId, paymentIntentId);
    }

    public void UpdateStripeSessionId(Guid id, string sessionId)
    {
        _orderDal.UpdateStripeSessionId(id, sessionId);
    }

    public List<Order> GetListWithUserAndMembershipWithId(Guid id)
    {
        return _orderDal.GetListWithUserAndMembershipWithId(id);
    }
}