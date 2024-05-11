
namespace MMNNDotNetCore.Business.Service;

public class DapperService
{
    public List<T> GetList<T>(string query)
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        var lst = db.Query<T>(query).ToList();
        return lst;
    }
    
    public List<T> GetList<T>(string query, object para)
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        var lst = db.Query<T>(query, para).ToList();
        return lst;
    }

    public int Execute(string query, object para)
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        return db.Execute(query, para);
    }

    public T? GetFirstById<T>(string query, object para)
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        return db.Query<T>(query, para).FirstOrDefault();
    }

}