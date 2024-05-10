namespace MMNNDotNetCore.ConsoleApp.Features;

public class AdoDotNetExamples
{
    private DataGenerateService _dataGenerateService = new DataGenerateService();
    public void SelectAll()
    {
        Console.WriteLine("-----Select Blog list-----");

        DataTable data = new DataTable();

        using (SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString))
        {
            SqlCommand command = new SqlCommand(Query.Select, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
        }

        foreach (DataRow item in data.Rows)
        {
            _dataGenerateService.WriteDataList(new BlogModel()
            {
                BlogId = Convert.ToInt32(item["BlogId"]),
                BlogTitle = item["BlogTitle"].ToString()!,
                BlogAuthor = item["BlogAuthor"].ToString()!,
                BlogContent = item["BlogContent"].ToString()!
            });
        }
    }

    public void SelectBy()
    {
        string query = string.Empty;
        SqlParameter para = _dataGenerateService.GetFilters(out query);
        DataTable data = new DataTable();

        using (SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(para);
            // command.Parameters.AddWithValue("@Author", author);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
        }
        
        foreach (DataRow item in data.Rows)
        {
            _dataGenerateService.WriteDataList(new BlogModel()
            {
                BlogId = Convert.ToInt32(item["BlogId"]),
                BlogTitle = item["BlogTitle"].ToString()!,
                BlogAuthor = item["BlogAuthor"].ToString()!,
                BlogContent = item["BlogContent"].ToString()!
            });
        }
    }

    public void Create()
    {
        Console.WriteLine("----- Create Blog -----");
        BlogModel newBlog = _dataGenerateService.GetUserInputBlog();
        
        int result;
        using (SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(Query.Create,connection);
            cmd.Parameters.AddWithValue("@BlogTitle", newBlog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", newBlog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", newBlog.BlogContent);
            
            result = cmd.ExecuteNonQuery();
            connection.Close();
        }
        
        string message = result > 0 ? "---- Saving Successful. ----" : "---- Saving Fail! ----";
        Console.WriteLine(message);
    }

    public void Update()
    {
        Console.WriteLine("----- Update Blog -----");
        int id = _dataGenerateService.GetEditBlogId();
        
        DataTable data = new DataTable();
        int result;
        
        using (SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString))
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

            Console.WriteLine("----- Blog Info -----");
            _dataGenerateService.WriteDataList(new BlogModel()
            {
                BlogId = Convert.ToInt32(data.Rows[0]["BlogId"]),
                BlogTitle = data.Rows[0]["BlogTitle"].ToString()!,
                BlogAuthor = data.Rows[0]["BlogAuthor"].ToString()!,
                BlogContent = data.Rows[0]["BlogContent"].ToString()!
            });
            
            BlogModel newBlog = _dataGenerateService.GetUserInputBlog();
            
            connection.Open();
            SqlCommand cmd = new SqlCommand(Query.Update,connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", newBlog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", newBlog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", newBlog.BlogContent);
            
            result = cmd.ExecuteNonQuery();
            connection.Close();
        }
        
        string message = result > 0 ? "---- Update Successful. ----" : "---- Update Fail! ----";
        Console.WriteLine(message);
    }

    public void Delete()
    {
        Console.WriteLine("----- Delete Blog -----");
        int id = _dataGenerateService.GetEditBlogId();
        
        DataTable data = new DataTable();
        int result;
        
        using (SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString))
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

            Console.WriteLine("----- Blog Info -----");
            _dataGenerateService.WriteDataList(new BlogModel()
            {
                BlogId = Convert.ToInt32(data.Rows[0]["BlogId"]),
                BlogTitle = data.Rows[0]["BlogTitle"].ToString()!,
                BlogAuthor = data.Rows[0]["BlogAuthor"].ToString()!,
                BlogContent = data.Rows[0]["BlogContent"].ToString()!
            });
            
            if (!_dataGenerateService.ConfirmToDelete())
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