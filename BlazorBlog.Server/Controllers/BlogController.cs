using BlazorBlog.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    public List<BlogPost> Posts { get; set; } = new()
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

    [HttpGet]
    public ActionResult<List<BlogPost>> GetAllBlogPosts()
    {
        return Ok(Posts);
    }

    [HttpGet("{url}")]
    public ActionResult<BlogPost> GetOneBlogPost(string url)
    {
        var post = Posts.FirstOrDefault(p => p.Url.Equals(url));
        if (post is null)
        {
            return NotFound("This post does not exist");
        }

        return Ok(post);
    }
}