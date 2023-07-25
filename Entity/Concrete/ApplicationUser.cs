using Microsoft.AspNetCore.Identity;

namespace Entity.Concrete;

public class ApplicationUser : IdentityUser
{
    
   
    public string? FirstName { get; set; }


    public string? LastName { get; set; }

    
    public string? ImageUrl { get; set; }

    
    public string? City { get; set; }

   
    public string? District { get; set; }

}