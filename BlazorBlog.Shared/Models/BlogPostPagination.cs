namespace BlazorBlog.Shared.Models;

public class BlogPostPagination
{
    public int TotalCount { get; set; }
    public List<BlogPost> Data { get; set; }
}