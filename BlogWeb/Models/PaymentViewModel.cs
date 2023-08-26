namespace BlogWeb.Models;

public class PaymentViewModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    
    public string? Name { get; set; }
    public double Price { get; set; }
    
    public Guid MembershipId { get; set; }
    public string? PhoneNumber { get; set; }
    
}