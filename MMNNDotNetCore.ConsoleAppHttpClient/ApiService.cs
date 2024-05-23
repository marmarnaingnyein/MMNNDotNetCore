using System.Net.Mime;
using System.Text;
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

    public async Task<BlogModel?> SelectById(int id)
    {
        BlogModel? model = null;
        BlogModel filter = new BlogModel() { BlogId = id };
        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(filter), Encoding.UTF8,
            MediaTypeNames.Application.Json);
        var response = await _client.PostAsync($"{_blogEndPoint}/selectBy", httpContent);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
        }

        return model;
    }

    public async Task<string> Create(BlogModel reqModel)
    {
        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(reqModel), Encoding.UTF8,
            MediaTypeNames.Application.Json);
        var response = await _client.PostAsync(_blogEndPoint, httpContent);
        string resMsg = await response.Content.ReadAsStringAsync();
        return resMsg;
    }
    
    public async Task<string> Update(BlogModel reqModel)
    {
        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(reqModel), Encoding.UTF8,
            MediaTypeNames.Application.Json);
        var response = await _client.PutAsync(_blogEndPoint, httpContent);
        string resMsg = await response.Content.ReadAsStringAsync();
        return resMsg;
    }
    
    public async Task<string> Delete(int id)
    {
        var response = await _client.DeleteAsync($"{_blogEndPoint}/{id}");
        string resMsg = await response.Content.ReadAsStringAsync();
        return resMsg;
    }
}