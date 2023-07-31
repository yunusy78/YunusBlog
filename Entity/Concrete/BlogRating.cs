using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete;

public class BlogRating
{
    public Guid Id { get; set; }
    
    public int TotalRating { get; set; }
    
    public int TotalRatingCount { get; set; }
    
    public Guid BlogId { get; set; }
    [ForeignKey("BlogId")]
    
    public Blog Blog { get; set; }
}