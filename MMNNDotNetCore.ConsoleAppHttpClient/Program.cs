using MMNNDotNetCore.Models;
using Newtonsoft.Json;

HttpClient client = new HttpClient();
var response = await client.GetAsync("https://localhost:7253/api/Blog");
if (response.IsSuccessStatusCode)
{
    string jsonStr = await response.Content.ReadAsStringAsync();
    List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
    foreach (var item in lst)
    {
        Console.WriteLine(JsonConvert.SerializeObject(item));
        
    }
}