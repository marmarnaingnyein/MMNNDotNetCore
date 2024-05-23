using MMNNDotNetCore.Models;

namespace MMNNDotNetCore.ConsoleAppHttpClient;

public class HttpClientExamples
{
    private readonly ApiService _apiService = new ApiService();

    public async Task RunAsnc()
    {
        await GetList();
        await GetById(1);
        await Create("Habbit", "MM", "Habbit is daily task");
        await Update(3, "Sleeping", "Phyo", "I can sleep the whole day.");
        await Delete(3);
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

    public async Task Create(string title, string author, string content)
    {
        BlogModel model = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        string res = await _apiService.Create(model);
        Console.WriteLine(res);
    }
    
    public async Task Update(int id, string title, string author, string content)
    {
        BlogModel model = new BlogModel()
        {
            BlogId = id,
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        string res = await _apiService.Update(model);
        Console.WriteLine(res);
    }

    public async Task Delete(int id)
    {
        var res = await _apiService.Delete(id);
        Console.WriteLine(res);
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