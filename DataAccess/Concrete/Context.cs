﻿using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class Context:IdentityDbContext<ApplicationUser>
{
    public Context(DbContextOptions<Context> options):base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Message2>()
            .HasOne(x=>x.SenderWriter)
            .WithMany(x=>x.MessageSender)
            .HasForeignKey(x=>x.SenderId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<Message2>()
            .HasOne(x=>x.ReceiverWriter)
            .WithMany(x=>x.MessageReceiver)
            .HasForeignKey(x=>x.ReceiverId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
    }
    
    public DbSet<About> Abouts { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Writer> Writers { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Newsletter> Newsletters { get; set; }
    public DbSet<BlogRating> BlogRatings { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Message2> Message2S { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    
    
}