using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete;

public class Comment
{
    public Guid Id { get; set; }
    
    public string? UserName { get; set; }=string.Empty;
    
    public string? Title { get; set; }=string.Empty;
    
    public string? Content { get; set; }=string.Empty;
    
    public DateTime CreatedAt { get; set; }
    
    public bool Status { get; set; }
    
    public int BlogRating { get; set; }
    
    public Guid BlogId { get; set; }
    [ForeignKey("BlogId")]
    
    public Blog Blog { get; set; }
    
    
}