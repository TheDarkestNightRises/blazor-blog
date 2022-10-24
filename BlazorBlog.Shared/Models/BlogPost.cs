using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Shared.Models;

public class BlogPost
{
    public int Id { get; set; }
    [Required, StringLength(20,ErrorMessage = "Please use only 20 characters")]
    public string Url { get; set; }

    public string Image { get; set; }
    [Required]
    public string Title { get; set; }
    public string Content { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string Author { get; set; }
    public bool IsPublished { get; set; } = true;
    public bool IsDeleted { get; set; } = false;    
}