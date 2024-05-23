using System.Net.Mime;
using System.Text;
using MMNNDotNetCore.Models;
using Newtonsoft.Json;
using RestSharp;

namespace MMNNDotNetCore.ConsoleAppRestClient;

public class ApiService
{
    private readonly RestClient _client = new RestClient("https://localhost:7253");
    private readonly string _blogEndPoint = "api/blog";

    public async Task<List<BlogModel>> GetBlogList()
    {
        List<BlogModel> lst = new List<BlogModel>();
        RestRequest request = new RestRequest(_blogEndPoint, Method.Get);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content;
            lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
        }

        return lst;
    }

    public async Task<BlogModel?> SelectById(int id)
    {
        BlogModel? model = null;
        BlogModel filter = new BlogModel() { BlogId = id };
        RestRequest request = new RestRequest($"{_blogEndPoint}/selectBy", Method.Post);
        request.AddJsonBody(filter);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content;
            model = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
        }

        return model;
    }

    public async Task<string> Create(BlogModel reqModel)
    {
        RestRequest request = new RestRequest(_blogEndPoint, Method.Post);
        request.AddJsonBody(reqModel);
        var response = await _client.PostAsync(request);
        return response.Content;
    }
    
    public async Task<string> Update(BlogModel reqModel)
    {
        RestRequest request = new RestRequest(_blogEndPoint, Method.Put);
        request.AddJsonBody(reqModel);
        var response = await _client.ExecuteAsync(request);
        return response.Content;
    }
    
    public async Task<string> Delete(int id)
    {
        RestRequest request = new RestRequest($"{_blogEndPoint}/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(request);
        return response.Content;
    }
}