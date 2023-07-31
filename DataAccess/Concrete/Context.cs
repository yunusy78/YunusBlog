using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class Context:IdentityDbContext<ApplicationUser,ApplicationRole,string> 
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Blog;Trusted_Connection=True;");
    }
    
    public DbSet<About> Abouts { get; set; }
    public DbSet<Entity.Concrete.Blog> Blogs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Writer> Writers { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Newsletter> Newsletters { get; set; }
    public DbSet<BlogRating> BlogRatings { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    
}