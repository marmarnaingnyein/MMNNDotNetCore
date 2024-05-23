using MMNNDotNetCore.Models;
using Newtonsoft.Json;

namespace MMNNDotNetCore.ConsoleAppHttpClient;

public class ApiService
{
    private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7253") };
    private readonly string _blogEndPoint = "api/blog";

    public async Task<List<BlogModel>> GetBlogList()
    {
        List<BlogModel> lst = new List<BlogModel>();
        var response = await _client.GetAsync(_blogEndPoint);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
        }

        return lst;
    }
    
    
}