using BlazorBlog.Shared.Models;

namespace BlazorBlog.Presentation.Services;

public interface IBlogService
{
    Task<List<BlogPost>> GetBlogPosts();
    Task<BlogPost> GetBlogPostByUrl(string url);
}