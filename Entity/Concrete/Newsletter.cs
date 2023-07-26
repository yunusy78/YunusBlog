using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete;

public class Newsletter
{
    [Key]
    public Guid Id { get; set; }
    
    public string Email { get; set; }=string.Empty;
    
    public DateTime CreatedAt { get; set; }
    
    public bool Status { get; set; }
}