using BlazorBlog.Shared.Models;

namespace BlazorBlog.Presentation.Services;

public interface IBlogService
{
    List<BlogPost> GetBlogPosts();
    BlogPost GetBlogPostByUrl(string url);
}