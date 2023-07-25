namespace Entity.Concrete;

public class Writer
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }=string.Empty;
    
    public string About { get; set; }=string.Empty;
    
    public string ImageUrl { get; set; }=string.Empty;
    
    public string Email { get; set; }=string.Empty;
    
    public string Password { get; set; }=string.Empty;
    
    public DateTime CreatedAt { get; set; }
    
    public bool Status { get; set; }
    
    
}