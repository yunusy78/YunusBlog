using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete;

public class Blog
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }=string.Empty;
    
    public string Content { get; set; }=string.Empty;
    
    public DateTime CreatedAt { get; set; }
    
    public bool Status { get; set; }
    
    public string ImageUrl { get; set; }=string.Empty;
    
    public string ThumbnailImageUrl { get; set; }=string.Empty;
    
    public Guid CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    
    public Category Category { get; set; }

    public List<Comment> Comments{ get; set; }
}