using System.Data;
using System.Data.SqlClient;

namespace MMNNDotNetCore.ConsoleApp;

public class AdoDotNetExamples
{
    private SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "DotNetTrainingBatch4",
        UserID = "sa",
        Password = "sa@123",
    };

    public void SelectAll()
    {
        Console.WriteLine("-----Select Operation list-----");

        DataTable data = new DataTable();

        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
            SqlCommand command = new SqlCommand(Query.Select, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
        }

        foreach (DataRow item in data.Rows)
        {
            Console.WriteLine("Blog Id => " + item["BlogId"]);
            Console.WriteLine("Blog Title => " + item["BlogTitle"]);
            Console.WriteLine("Blog Author => " + item["BlogAuthor"]);
            Console.WriteLine("Blog Content => " + item["BlogContent"]);
            Console.WriteLine("===============================");
        }
    }

    public void SelectBy()
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
                Console.WriteLine("Please enter Blog Id");
                id = Console.ReadLine()!;
                break;
            case 2:
                Console.WriteLine("Please enter title");
                title = Console.ReadLine()!;
                break;
            case 3:
                Console.WriteLine("Please enter author");
                author = Console.ReadLine()!;
                break;
        }

        SqlParameter para = new SqlParameter();
        string query = Query.Select + " Where ";
        if (!string.IsNullOrEmpty(id))
        {
            query += "BlogId = @BlogId";
            para = new SqlParameter("@BlogId", id);
        }
        else if (!string.IsNullOrEmpty(title))
        {
            query += "BlogTitle like '%@Title%'";
            para = new SqlParameter("@Title", title);
        }
        else if (!string.IsNullOrEmpty(author))
        {
            query += "BlogAuthor like '%@Author%'";
            para = new SqlParameter("@Author", author);
        }
        
        DataTable data = new DataTable();

        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(para);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
        }
        
        foreach (DataRow item in data.Rows)
        {
            Console.WriteLine("---- Select By Filter -----");
            Console.WriteLine("Blog Id => " + item["BlogId"]);
            Console.WriteLine("Blog Title => " + item["BlogTitle"]);
            Console.WriteLine("Blog Author => " + item["BlogAuthor"]);
            Console.WriteLine("Blog Content => " + item["BlogContent"]);
            Console.WriteLine("===============================");
        }
    }

    public void Create()
    {
        Console.WriteLine("----- Create Blog -----");

        BlogModel newBlog = new BlogModel();
        
        Console.WriteLine("Please enter new Blog Title");
        newBlog.Title = Console.ReadLine()!;
        
        Console.WriteLine("Please enter new Author");
        newBlog.Author = Console.ReadLine()!;
        
        Console.WriteLine("Please enter new Content");
        newBlog.Content = Console.ReadLine()!;
        int result;
        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(Query.Create,connection);
            cmd.Parameters.AddWithValue("@BlogTitle", newBlog.Title);
            cmd.Parameters.AddWithValue("@BlogAuthor", newBlog.Author);
            cmd.Parameters.AddWithValue("@BlogContent", newBlog.Content);
            
            result = cmd.ExecuteNonQuery();
        }
        
        string message = result > 0 ? "---- Saving Successful. ----" : "---- Saving Fail! ----";
        Console.WriteLine(message);
    }
}