using Entity.Concrete;

namespace DataAccess.Abstract;

public interface IOrderDal : IGenericDal<Order>
{
    List<Order> GetListWithUserAndMembership();
    void UpdateStatus(Guid id, string orderStatus, string? paymentStatus=null);
    public void UpdateStripePaymentId(Guid id, string sessionId, string paymentIntentId);
    public void UpdateStripeSessionId(Guid id, string sessionId);
    
    List<Order> GetListWithUserAndMembershipWithId(Guid id);
    
}