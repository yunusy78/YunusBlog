using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete;

public partial class Blog
{
    [NotMapped]
    public string EncryptedId { get; set; }
    
}