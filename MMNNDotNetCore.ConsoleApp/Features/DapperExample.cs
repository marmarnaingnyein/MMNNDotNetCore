using System.Data;
using System.Data.SqlClient;
using Dapper;
using MMNNDotNetCore.ConsoleApp.Service;

namespace MMNNDotNetCore.ConsoleApp.Features;

public class DapperExample
{    
    private DataGenerateService _dataGenerateService = new DataGenerateService();

    public void SelectAll()
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        List<BlogModel> lst = db.Query<BlogModel>(Query.Select).ToList();

        foreach (var item in lst)
        {
            _dataGenerateService.WriteDataList(item);
        }
    }

    public void SelectBy()
    {
        string query = string.Empty;
        BlogModel para = _dataGenerateService.GetFiltersBlog(out query);
        
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        List<BlogModel> lst = db.Query<BlogModel>(query, para).ToList();

        foreach (var item in lst)
        {
            _dataGenerateService.WriteDataList(item);
        }
    }

    public void Edit(int id)
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        var item = db.Query(Query.SelectById, 
            new BlogModel { BlogId = id }).FirstOrDefault();

        if (item is null)
        {
            Console.WriteLine("No Data Fount!");
            return;
        }
        
        _dataGenerateService.WriteDataList(item);
    }

    public void Create()
    {
        Console.WriteLine("----- Create Blog -----");
        BlogModel newBlog = _dataGenerateService.GetUserInputBlog();
        
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(Query.Create, newBlog);
        
        string message = result > 0 ? "---- Saving Successful. ----" : "---- Saving Fail! ----";
        Console.WriteLine(message);
    }

    public void Update()
    {
        
    }

    public void Delete()
    {
        Console.WriteLine("----- Delete Blog -----");
        int id = _dataGenerateService.GetEditBlogId();
        
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        
        BlogModel? item = db.Query<BlogModel>(Query.SelectById, 
            new BlogModel { BlogId = id }).FirstOrDefault();

        if (item is null)
        {
            Console.WriteLine("No Data Fount!");
            return;
        }

        Console.WriteLine("----- Blog Info -----");
        _dataGenerateService.WriteDataList(item);
            
        if (!_dataGenerateService.ConfirmToDelete())
        {
            return;
        }

        int result = db.Execute(Query.Delete, 
            new BlogModel { BlogId = id });
        
        string message = result > 0 ? "---- Delete Successful. ----" : "---- Delete Fail! ----";
        Console.WriteLine(message);
    }
}