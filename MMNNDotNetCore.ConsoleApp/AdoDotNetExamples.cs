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

    public bool Read()
    {
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

        return true;
    }
    
    
}