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

    public async Task<List<BlogPost>> GetBlogPostsAsync()
    {
        return await _client.GetFromJsonAsync<List<BlogPost>>("/api/Blog");
    }

    public async Task<BlogPost> GetBlogPostByUrlAsync(string url)
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

    public async Task<BlogPost> CreateNewBlogPost(BlogPost request)
    {
        HttpResponseMessage response = await _client.PostAsJsonAsync("/api/Blog/",request);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
        return await response.Content.ReadFromJsonAsync<BlogPost>();
    }
}