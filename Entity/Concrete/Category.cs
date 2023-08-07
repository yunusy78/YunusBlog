using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete;

public class Category
{
    [Key]
    public Guid CategoryId { get; set; }
    
    [Required(ErrorMessage = "Category Name is required.")]
    public string Name { get; set; }=string.Empty;
    
    [Required(ErrorMessage = "Description is required.")]
    public  string Description { get; set; }=string.Empty;
    
    public string ImageUrl { get; set; }=string.Empty;
    
    public DateTime CreatedAt { get; set; }

    public bool Status { get; set; }
    
    public List<Blog> Blogs { get; set; }
}