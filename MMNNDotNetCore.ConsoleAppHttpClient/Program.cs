HttpClient client = new HttpClient();
var response = await client.GetAsync("https://localhost:7253");
if (response.IsSuccessStatusCode)
{
    string jsonStr = await response.Content.ReadAsStringAsync();
    Console.WriteLine(jsonStr);
}