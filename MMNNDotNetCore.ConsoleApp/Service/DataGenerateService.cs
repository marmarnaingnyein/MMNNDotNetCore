using System.Data.SqlClient;

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

    public SqlParameter GetFilters(out string query)
    {
        Console.WriteLine("Please choose your filter by...");
        Console.WriteLine("1. Select by Blog Id");
        Console.WriteLine("2. Select by Title");
        Console.WriteLine("3. Select by Author");
        int choice = Convert.ToInt32(Console.ReadLine());
        
        while (choice is <= 0 or > 3)
        {
            Console.WriteLine("Enter your choice number:");
            choice = Convert.ToInt32(Console.ReadLine());
        }

        string id = string.Empty;
        string title = string.Empty;
        string author = String.Empty;
        switch (choice)
        {
            case 1:
                while (string.IsNullOrEmpty(id))
                {
                    Console.WriteLine("Please enter Blog Id");
                    id = Console.ReadLine()!;
                }
                break;
            case 2:
                while (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("Please enter title");
                    title = Console.ReadLine()!;
                }
                break;
            case 3:
                while (string.IsNullOrEmpty(author))
                {
                    Console.WriteLine("Please enter author");
                    author = Console.ReadLine()!;
                }
                break;
        }

        SqlParameter para = new SqlParameter();
        query = Query.Select + " Where ";
        if (!string.IsNullOrEmpty(id))
        {
            query += "BlogId = @BlogId";
            para = new SqlParameter("@BlogId", id);
        }
        else if (!string.IsNullOrEmpty(title))
        {
            query += "BlogTitle = @Title";
            para = new SqlParameter("@Title", title);
        }
        else if (!string.IsNullOrEmpty(author))
        {
            query += "BlogAuthor = @Author";
            para = new SqlParameter("@Author", author);
        }

        return para;
    }

    public BlogModel GetFiltersBlog(out string query)
    {
        
        Console.WriteLine("Please choose your filter by...");
        Console.WriteLine("1. Select by Blog Id");
        Console.WriteLine("2. Select by Title");
        Console.WriteLine("3. Select by Author");
        int choice = Convert.ToInt32(Console.ReadLine());
        
        while (choice is <= 0 or > 3)
        {
            Console.WriteLine("Enter your choice number:");
            choice = Convert.ToInt32(Console.ReadLine());
        }

        string id = string.Empty;
        string title = string.Empty;
        string author = String.Empty;
        switch (choice)
        {
            case 1:
                while (string.IsNullOrEmpty(id))
                {
                    Console.WriteLine("Please enter Blog Id");
                    id = Console.ReadLine()!;
                }
                break;
            case 2:
                while (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("Please enter title");
                    title = Console.ReadLine()!;
                }
                break;
            case 3:
                while (string.IsNullOrEmpty(author))
                {
                    Console.WriteLine("Please enter author");
                    author = Console.ReadLine()!;
                }
                break;
        }

        BlogModel filter = new BlogModel();
        query = Query.Select + " Where ";
        if (!string.IsNullOrEmpty(id))
        {
            query += "BlogId = @BlogId";
            filter.BlogId = Convert.ToInt32(id);
        }
        else if (!string.IsNullOrEmpty(title))
        {
            query += "BlogTitle = @BlogTitle";
            filter.BlogTitle = title;
        }
        else if (!string.IsNullOrEmpty(author))
        {
            query += "BlogAuthor = @BlogAuthor";
            filter.BlogAuthor = author;
        }

        return filter;
    }
    
    public BlogModel GetFiltersBlog()
    {
        Console.WriteLine("Please choose your filter by...");
        Console.WriteLine("1. Select by Blog Id");
        Console.WriteLine("2. Select by Title");
        Console.WriteLine("3. Select by Author");
        int choice = Convert.ToInt32(Console.ReadLine());
        
        while (choice is <= 0 or > 3)
        {
            Console.WriteLine("Enter your choice number:");
            choice = Convert.ToInt32(Console.ReadLine());
        }

        string id = string.Empty;
        string title = string.Empty;
        string author = String.Empty;
        switch (choice)
        {
            case 1:
                while (string.IsNullOrEmpty(id))
                {
                    Console.WriteLine("Please enter Blog Id");
                    id = Console.ReadLine()!;
                }
                break;
            case 2:
                while (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("Please enter title");
                    title = Console.ReadLine()!;
                }
                break;
            case 3:
                while (string.IsNullOrEmpty(author))
                {
                    Console.WriteLine("Please enter author");
                    author = Console.ReadLine()!;
                }
                break;
        }

        BlogModel filter = new BlogModel();
        if (!string.IsNullOrEmpty(id))
        {
            filter.BlogId = Convert.ToInt32(id);
        }
        else if (!string.IsNullOrEmpty(title))
        {
            filter.BlogTitle = title;
        }
        else if (!string.IsNullOrEmpty(author))
        {
            filter.BlogAuthor = author;
        }

        return filter;
    }
}