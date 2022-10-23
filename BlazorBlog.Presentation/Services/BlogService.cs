using System.Net.Http.Json;
using BlazorBlog.Shared.Models;

namespace BlazorBlog.Presentation.Services;

public class BlogService : IBlogService
{
    private readonly HttpClient _client;

    public BlogService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<BlogPost>> GetBlogPosts()
    {
        return await _client.GetFromJsonAsync<List<BlogPost>>("/api/Blog");
    }

    public async Task<BlogPost> GetBlogPostByUrl(string url)
    {
        var result = await _client.GetAsync($"/api/Blog/{url}");
        if (result.StatusCode != System.Net.HttpStatusCode.OK)
        {
            var message = await result.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            return new BlogPost { Title = message };
        }
        else
        {
            return await result.Content.ReadFromJsonAsync<BlogPost>();
        }
    }
}