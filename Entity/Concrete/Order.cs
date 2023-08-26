using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete;

public class Order
{
    public Guid Id { get; set; }
    
    public string?  UserId  { get; set; }
    
    public ApplicationUser? User { get; set; }
    
    public string PaymentStatus { get; set; }=string.Empty;
    
    public string PaymentType { get; set; }=string.Empty;
    
    public DateTime? PaymentDate { get; set; }
    
    public string SessionId { get; set; }=string.Empty;
    
    public string PaymentIntentId { get; set; }=string.Empty;
    
    public DateTime OrderDate { get; set; }
    
    public Membership? Membership { get; set; }
    
    public Guid MembershipId { get; set; }
   
    [ForeignKey("MembershipId")]
    
    public string? Status { get; set; }
    
    public double Price { get; set; }
}
