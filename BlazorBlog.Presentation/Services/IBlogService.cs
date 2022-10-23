using BlazorBlog.Shared.Models;

namespace BlazorBlog.Presentation.Services;

public interface IBlogService
{
    Task<List<BlogPost>> GetBlogPostsAsync();
    Task<BlogPost> GetBlogPostByUrlAsync(string url);
    Task<BlogPost> CreateNewBlogPost(BlogPost request);

}