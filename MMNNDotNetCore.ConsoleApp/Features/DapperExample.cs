using System.Data;
using System.Data.SqlClient;
using Dapper;
using MMNNDotNetCore.ConsoleApp.Service;

namespace MMNNDotNetCore.ConsoleApp.Features;

public class DapperExample
{    
    private DataGenerateService _dataGenerateService = new DataGenerateService();

    public void Run()
    {
        Read();
    }

    private void Read()
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        List<BlogModel> lst = db.Query<BlogModel>(Query.Select).ToList();

        foreach (var item in lst)
        {
            _dataGenerateService.WriteDataList(item);
        }
    }

    private void Edit(int id)
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

    private void Create()
    {
        Console.WriteLine("----- Create Blog -----");
        BlogModel newBlog = _dataGenerateService.GetUserInputBlog();
        
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(Query.Create, newBlog);
        
        string message = result > 0 ? "---- Saving Successful. ----" : "---- Saving Fail! ----";
        Console.WriteLine(message);
    }
}