using BlazorBlog.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Database.Migrate();
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BlogPost>().HasData(new BlogPost
        {
            Id = 1,
            Url = "new-blog2",
            Author = "Me",
            Title = "Lol",
            Description = "This is a bad blog",
            Content = "Lorem Ipsum Dolor sit Atmet",
            Image = ""
        });
        modelBuilder.Entity<BlogPost>().HasData(new BlogPost
        {
            Id = 2,
            Url = "new-blog1",
            Author = "Me",
            Title = "Lol2",
            Description = "This is a bad blog",
            Content = "Lorem Ipsum Dolor sit Atmet",
            Image=""
        });
    }
    
    public DbSet<BlogPost> BlogPosts { get; set; }
}