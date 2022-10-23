using BlazorBlog.Shared.Models;

namespace BlazorBlog.Presentation.Services;

public class BlogService : IBlogService
{
    public List<BlogPost?> Posts { get; set; } = new()
    {
        new BlogPost
        {
            Url = "new-blog2",
            Title = "Lol",
            Description = "This is a bad blog"
        },
        new BlogPost
        {
            Url = "new-blog1",
            Title = "Lol2",
            Description = "This is a bad blog"
        },
    };

    
    public List<BlogPost?> GetBlogPosts()
    {
        return Posts;
    }

    public BlogPost? GetBlogPostByUrl(string url)
    {
        return Posts.FirstOrDefault(p => p.Url.Equals(url));
    }
}