using MMNNDotNetCore.Models;
using Refit;

namespace MMNNDotNetCore.ConsoleAppRefitExamples;

public class RefitExample
{
    private readonly WriteDataService _writeData;
    private readonly IBlogApi _service = RestService.For<IBlogApi>("https://localhost:7253");
    
    public RefitExample()
    {
        _writeData = new WriteDataService();
    }

    public async Task RunAsnc()
    {
        await GetList();
        await GetById(1);
        await Create("Habbit", "MM", "Habbit is daily task");
        await Update(4, "Sleeping", "Phyo", "I can sleep the whole day.");
        await Delete(4);
    }
    
    public async Task GetList()
    {
        List<BlogModel> lst = await _service.GetBlogs();
        foreach (var item in lst)
        {
            _writeData.WriteData(item);
        }
    }

    public async Task GetById(int id)
    {
        try
        {
            BlogModel? item = await _service.SelectBy(new BlogModel(){BlogId = id});
            if (item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
        
            Console.WriteLine(item);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task Create(string title, string author, string content)
    {
        try
        {
            BlogModel model = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string message = await _service.Create(model);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    public async Task Update(int id, string title, string author, string content)
    {
        try
        {
            BlogModel model = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string message = await _service.Update(model);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    public async Task Delete(int id)
    {
        try
        {
            string message = await _service.Delete(id);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}