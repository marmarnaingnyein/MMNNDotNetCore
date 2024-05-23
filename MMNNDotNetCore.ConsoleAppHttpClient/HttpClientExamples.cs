using MMNNDotNetCore.Models;

namespace MMNNDotNetCore.ConsoleAppHttpClient;

public class HttpClientExamples
{
    private readonly ApiService _apiService = new ApiService();

    public async Task RunAsnc()
    {
        await GetList();
    }
    
    public async Task GetList()
    {
        List<BlogModel> lst = await _apiService.GetBlogList();
        foreach (var item in lst)
        {
            Console.WriteLine($"Blog Id : {item.BlogId}");
            Console.WriteLine($"Blog Title : {item.BlogTitle}");
            Console.WriteLine($"Blog Author : {item.BlogAuthor}");
            Console.WriteLine($"Blog Content : {item.BlogContent}");
            Console.WriteLine("===============================");
        }
    }
    
    
}