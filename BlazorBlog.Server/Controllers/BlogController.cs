using BlazorBlog.Server.Data;
using BlazorBlog.Server.Helper;
using BlazorBlog.Server.Repository;
using BlazorBlog.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly IBlogRepository _blogRepository;

    public BlogController(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<BlogPost>>> GetAllBlogPostsAsync([FromQuery]PaginationDto paginationDto)
    {
        var posts = await _blogRepository.GetAllBlogPostsAsync();
        await HttpContext.InsertPaginationParamaterInResponse(posts, paginationDto.MaxPerPage);
        return await posts.Paginate(paginationDto).ToListAsync();
    }

    [HttpGet("{url}")]
    public async Task<ActionResult<BlogPost>> GetBlogPostAsync(string url)
    {
        var post = await _blogRepository.GetBlogPostAsync(url);
        if (post is null)
        {
            return NotFound("This post does not exist");
        }
        return Ok(post);
    }

    [HttpPost]
    public async Task<ActionResult<BlogPost>> CreateNewBlogPostAsync(BlogPost request)
    {
       return await _blogRepository.CreateNewBlogPostAsync(request);
    }
}