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
            Console.WriteLine($"Blog Id : {item["BlogId"]}");
            Console.WriteLine($"Blog Title : {item["BlogTitle"]}");
            Console.WriteLine($"Blog Author : {item["BlogAuthor"]}");
            Console.WriteLine($"Blog Content : {item["BlogContent"]}");
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
        string query = Query.Select + " Where ";
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
        
        DataTable data = new DataTable();

        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(para);
            // command.Parameters.AddWithValue("@Author", author);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
        }
        
        foreach (DataRow item in data.Rows)
        {
            Console.WriteLine("---- Select By Filter -----");
            Console.WriteLine($"Blog Id : {item["BlogId"]}");
            Console.WriteLine($"Blog Title : {item["BlogTitle"]}");
            Console.WriteLine($"Blog Author : {item["BlogAuthor"]}");
            Console.WriteLine($"Blog Content : {item["BlogContent"]}");
            Console.WriteLine("===============================");
        }
    }

    public void Create()
    {
        Console.WriteLine("----- Create Blog -----");

        BlogModel newBlog = new BlogModel();
        
        while (string.IsNullOrEmpty(newBlog.Title))
        {
            Console.WriteLine("Please enter new Blog Title");
            newBlog.Title = Console.ReadLine()!;
        }

        while (string.IsNullOrEmpty(newBlog.Author))
        {
            Console.WriteLine("Please enter new Author");
            newBlog.Author = Console.ReadLine()!;
        }

        while (string.IsNullOrEmpty(newBlog.Content))
        {
            Console.WriteLine("Please enter new Content");
            newBlog.Content = Console.ReadLine()!;
        }
        
        int result;
        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(Query.Create,connection);
            cmd.Parameters.AddWithValue("@BlogTitle", newBlog.Title);
            cmd.Parameters.AddWithValue("@BlogAuthor", newBlog.Author);
            cmd.Parameters.AddWithValue("@BlogContent", newBlog.Content);
            
            result = cmd.ExecuteNonQuery();
            connection.Close();
        }
        
        string message = result > 0 ? "---- Saving Successful. ----" : "---- Saving Fail! ----";
        Console.WriteLine(message);
    }

    public void Update()
    {
        Console.WriteLine("----- Update Blog -----");
        int id = 0;

        while (id <= 0)
        {
            Console.WriteLine("Enter Blog Id:");
            string strId = Console.ReadLine()!;
            id = string.IsNullOrEmpty(strId) ? 0 : Convert.ToInt32(strId);
        }
        
        DataTable data = new DataTable();
        int result;
        
        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
            SqlCommand command = new SqlCommand(Query.SelectById, connection);
            command.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);

            if (data.Rows.Count == 0)
            {
                Console.WriteLine("Blog Id does not exist.");
                return;
            }

            BlogModel blogModel = new BlogModel()
            {
                BlogId = data.Rows[0]["BlogId"].ToString()!,
                Title = data.Rows[0]["BlogTitle"].ToString()!,
                Author = data.Rows[0]["BlogAuthor"].ToString()!,
                Content = data.Rows[0]["BlogContent"].ToString()!
            };
            
            Console.WriteLine("----- Blog Info -----");
            Console.WriteLine($"Blog Id : {blogModel.BlogId}");
            Console.WriteLine($"Blog Title : {blogModel.Title}");
            Console.WriteLine($"Blog Author : {blogModel.Author}");
            Console.WriteLine($"Blog Content : {blogModel.Content}");
            Console.WriteLine("===============================");
            
            BlogModel newBlog = new BlogModel();
        
            while (string.IsNullOrEmpty(newBlog.Title))
            {
                Console.WriteLine("Please enter update Blog Title");
                newBlog.Title = Console.ReadLine()!;
            }

            while (string.IsNullOrEmpty(newBlog.Author))
            {
                Console.WriteLine("Please enter update Author");
                newBlog.Author = Console.ReadLine()!;
            }

            while (string.IsNullOrEmpty(newBlog.Content))
            {
                Console.WriteLine("Please enter update Content");
                newBlog.Content = Console.ReadLine()!;
            }
            
            connection.Open();
            SqlCommand cmd = new SqlCommand(Query.Update,connection);
            cmd.Parameters.AddWithValue("@BlogId", blogModel.BlogId);
            cmd.Parameters.AddWithValue("@BlogTitle", newBlog.Title);
            cmd.Parameters.AddWithValue("@BlogAuthor", newBlog.Author);
            cmd.Parameters.AddWithValue("@BlogContent", newBlog.Content);
            
            result = cmd.ExecuteNonQuery();
            connection.Close();
        }
        
        string message = result > 0 ? "---- Update Successful. ----" : "---- Update Fail! ----";
        Console.WriteLine(message);
    }

    public void Delete()
    {
        Console.WriteLine("----- Update Blog -----");
        int id = 0;

        while (id <= 0)
        {
            Console.WriteLine("Enter Blog Id:");
            string strId = Console.ReadLine()!;
            id = string.IsNullOrEmpty(strId) ? 0 : Convert.ToInt32(strId);
        }
        
        DataTable data = new DataTable();
        int result;
        
        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
            SqlCommand command = new SqlCommand(Query.SelectById, connection);
            command.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            
            if (data.Rows.Count == 0)
            {
                Console.WriteLine("Blog Id does not exist.");
                return;
            }

            BlogModel blogModel = new BlogModel()
            {
                BlogId = data.Rows[0]["BlogId"].ToString()!,
                Title = data.Rows[0]["BlogTitle"].ToString()!,
                Author = data.Rows[0]["BlogAuthor"].ToString()!,
                Content = data.Rows[0]["BlogContent"].ToString()!
            };
            
            Console.WriteLine("----- Blog Info -----");
            Console.WriteLine($"Blog Id : {blogModel.BlogId}");
            Console.WriteLine($"Blog Title : {blogModel.Title}");
            Console.WriteLine($"Blog Author : {blogModel.Author}");
            Console.WriteLine($"Blog Content : {blogModel.Content}");
            Console.WriteLine("===============================");
            
            Console.WriteLine("Are you sure want to delete?");
            Console.WriteLine("Enter y or n");
            string confirm = Console.ReadLine()!;
            if (confirm.ToLower() == "n")
            {
                return;
            }
            
            connection.Open();
            SqlCommand cmd = new SqlCommand(Query.Delete,connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            
            result = cmd.ExecuteNonQuery();
            connection.Close();
        }
        
        string message = result > 0 ? "---- Delete Successful. ----" : "---- Delete Fail! ----";
        Console.WriteLine(message);
    }
}