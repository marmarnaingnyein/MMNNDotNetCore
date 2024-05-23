using MMNNDotNetCore.Models;

namespace MMNNDotNetCore.ConsoleAppHttpClient;

public class HttpClientExamples
{
    private readonly ApiService _apiService = new ApiService();

    public async Task RunAsnc()
    {
        await GetList();
        await GetById(1);
    }
    
    public async Task GetList()
    {
        List<BlogModel> lst = await _apiService.GetBlogList();
        foreach (var item in lst)
        {
            WriteData(item);
        }
    }

    public async Task GetById(int id)
    {
        BlogModel? item = await _apiService.SelectById(id);
        if (item is null)
        {
            Console.WriteLine("No Data Found.");
            return;
        }
        
        Console.WriteLine(item);
    }

    private void WriteData(BlogModel item)
    {
        Console.WriteLine($"Blog Id : {item.BlogId}");
        Console.WriteLine($"Blog Title : {item.BlogTitle}");
        Console.WriteLine($"Blog Author : {item.BlogAuthor}");
        Console.WriteLine($"Blog Content : {item.BlogContent}");
        Console.WriteLine("===============================");
    }
}