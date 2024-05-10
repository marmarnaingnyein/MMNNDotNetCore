namespace MMNNDotNetCore.ConsoleApp.Features;

public class AdoDotNetExamples
{
    private DataGenerateService _dataGenerateService = new DataGenerateService();
    private AdoDotNetService _adoDotNetService = new AdoDotNetService();
    public void SelectAll()
    {
        Console.WriteLine("-----Select Blog list-----");

        DataTable data = _adoDotNetService.GetList(Query.Select);
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
        DataTable data = _adoDotNetService.GetList(query, para);
        
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
        
        List<SqlParameter> lstpara = new List<SqlParameter>();
        lstpara.Add(new SqlParameter("@BlogTitle", newBlog.BlogTitle));
        lstpara.Add(new SqlParameter("@BlogAuthor", newBlog.BlogAuthor));
        lstpara.Add(new SqlParameter("@BlogContent", newBlog.BlogContent));
        
        int result = _adoDotNetService.Execute(Query.Create, lstpara.ToArray());

        string message = result > 0 ? "---- Saving Successful. ----" : "---- Saving Fail! ----";
        Console.WriteLine(message);
    }

    public void Update()
    {
        Console.WriteLine("----- Update Blog -----");
        int id = _dataGenerateService.GetEditBlogId();
        
        SqlParameter para = new SqlParameter("@BlogId", id);
        
        DataTable data = _adoDotNetService.GetList(Query.SelectById, para);
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
        
        List<SqlParameter> lstpara = new List<SqlParameter>();
        lstpara.Add(new SqlParameter("@BlogId", id));
        lstpara.Add(new SqlParameter("@BlogTitle", newBlog.BlogTitle));
        lstpara.Add(new SqlParameter("@BlogAuthor", newBlog.BlogAuthor));
        lstpara.Add(new SqlParameter("@BlogContent", newBlog.BlogContent));
        
        int result = _adoDotNetService.Execute(Query.Update, lstpara.ToArray());

        string message = result > 0 ? "---- Update Successful. ----" : "---- Update Fail! ----";
        Console.WriteLine(message);
    }

    public void Delete()
    {
        Console.WriteLine("----- Delete Blog -----");
        int id = _dataGenerateService.GetEditBlogId();
        
        SqlParameter para = new SqlParameter("@BlogId", id);

        DataTable data = _adoDotNetService.GetList(Query.SelectById, para);
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

        List<SqlParameter> lstpara = new List<SqlParameter>();
        lstpara.Add(new SqlParameter("@BlogId", id));
        
        int result = _adoDotNetService.Execute(Query.Delete, lstpara.ToArray());
        
        string message = result > 0 ? "---- Delete Successful. ----" : "---- Delete Fail! ----";
        Console.WriteLine(message);
    }
}