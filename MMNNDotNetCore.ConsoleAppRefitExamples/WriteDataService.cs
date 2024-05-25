using MMNNDotNetCore.Models;

namespace MMNNDotNetCore.ConsoleAppRefitExamples;

public class WriteDataService
{
    public void WriteData(BlogModel item)
    {
        Console.WriteLine($"Blog Id : {item.BlogId}");
        Console.WriteLine($"Blog Title : {item.BlogTitle}");
        Console.WriteLine($"Blog Author : {item.BlogAuthor}");
        Console.WriteLine($"Blog Content : {item.BlogContent}");
        Console.WriteLine("===============================");
    }
}