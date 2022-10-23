using BlazorBlog.Server.Data;
using BlazorBlog.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly DataContext _dataContext;

    public BlogController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public ActionResult<List<BlogPost>> GetAllBlogPosts()
    {
        return Ok(_dataContext.BlogPosts);
    }

    [HttpGet("{url}")]
    public ActionResult<BlogPost> GetOneBlogPost(string url)
    {
        var post = _dataContext.BlogPosts.FirstOrDefault(p => p.Url.Equals(url));
        if (post is null)
        {
            return NotFound("This post does not exist");
        }

        return Ok(post);
    }
}