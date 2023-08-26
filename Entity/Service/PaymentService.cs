namespace Entity.Service;

public class PaymentService
{
    public const string PaymentStatusPending = "Pending";
    public const string PaymentStatusApproved = "Approved";
    public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
    public const string PaymentStatusRejected = "Rejected";
    
    public const string SessionCart = "SessionShoppingCart";
}