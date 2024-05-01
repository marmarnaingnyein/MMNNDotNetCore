namespace MMNNDotNetCore.ConsoleApp.Service;

public class DataGenerateService
{
    public void WriteDataList(BlogModel item)
    {
        Console.WriteLine($"Blog Id : {item.BlogId}");
        Console.WriteLine($"Blog Title : {item.BlogTitle}");
        Console.WriteLine($"Blog Author : {item.BlogAuthor}");
        Console.WriteLine($"Blog Content : {item.BlogContent}");
        Console.WriteLine("===============================");
    }

    public BlogModel GetUserInputBlog()
    {
        BlogModel model = new BlogModel();
        
        while (string.IsNullOrEmpty(model.BlogTitle))
        {
            Console.WriteLine("Please enter Blog Title");
            model.BlogTitle = Console.ReadLine()!;
        }

        while (string.IsNullOrEmpty(model.BlogAuthor))
        {
            Console.WriteLine("Please enter Author");
            model.BlogAuthor = Console.ReadLine()!;
        }

        while (string.IsNullOrEmpty(model.BlogContent))
        {
            Console.WriteLine("Please enter Content");
            model.BlogContent = Console.ReadLine()!;
        }

        return model;
    }

    public int GetEditBlogId()
    {
        int id = 0;

        while (id <= 0)
        {
            Console.WriteLine("Enter Blog Id:");
            string strId = Console.ReadLine()!;
            id = string.IsNullOrEmpty(strId) ? 0 : Convert.ToInt32(strId);
        }

        return id;
    }

    public bool ConfirmToDelete()
    {
        Console.WriteLine("Are you sure want to delete?");
        Console.WriteLine("Enter y or n");
        string confirm = Console.ReadLine()!;
        if (confirm.ToLower() == "n")
        {
            return false;
        }

        return true;
    }
}