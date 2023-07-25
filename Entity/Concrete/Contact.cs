namespace Entity.Concrete;

public class Contact
{
    public Guid Id { get; set; }
    
    public string UserName { get; set; }=string.Empty;
    
    public string Email { get; set; }=string.Empty;
    
    public string Subject{ get; set; }=string.Empty;
    
    public string Message { get; set; }=string.Empty;
    
    public DateTime CreatedAt { get; set; }
    
    public bool Status { get; set; }
}