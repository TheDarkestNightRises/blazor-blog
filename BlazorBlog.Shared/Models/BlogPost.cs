namespace BlazorBlog.Shared.Models;

public class BlogPost
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string Author { get; set; }
    public bool IsPublished { get; set; } = true;
    public bool IsDeleted { get; set; } = false;    
}