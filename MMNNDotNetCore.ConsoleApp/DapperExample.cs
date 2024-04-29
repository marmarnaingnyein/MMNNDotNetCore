using System.Data;
using System.Data.SqlClient;

namespace MMNNDotNetCore.ConsoleApp;

public class DapperExample
{
    public void Run()
    {
        Read();
    }

    private void Read()
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        //List<dynamic> lst = db.Query
    }
}