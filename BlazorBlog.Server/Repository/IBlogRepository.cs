using BlazorBlog.Shared.Models;

namespace BlazorBlog.Server.Repository;

public interface IBlogRepository
{
    Task<List<BlogPost>> GetAllBlogPostsAsync();
    Task<BlogPost?> GetBlogPostAsync(string url);
    Task<BlogPost> CreateNewBlogPostAsync(BlogPost blogPost);
}