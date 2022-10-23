using BlazorBlog.Server.Data;
using BlazorBlog.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Server.Repository;

public class BlogRepository : IBlogRepository
{
    private readonly DataContext _dataContext;

    public BlogRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }


    public async Task<List<BlogPost>> GetAllBlogPostsAsync()
    {
       return await _dataContext.BlogPosts.ToListAsync();
    }

    public async Task<BlogPost?> GetBlogPostAsync(string url)
    {
        return await _dataContext.BlogPosts.FirstOrDefaultAsync(p => p.Url.Equals(url));
    }

    public async Task<BlogPost> CreateNewBlogPostAsync(BlogPost blogPost)
    {
        _dataContext.Add(blogPost);
        await _dataContext.SaveChangesAsync();
        return blogPost;
    }
}