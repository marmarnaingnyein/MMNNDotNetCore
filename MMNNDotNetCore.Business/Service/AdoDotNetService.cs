using Microsoft.IdentityModel.Tokens;
using MMNNDotNetCore.Shared;

namespace MMNNDotNetCore.Business.Service;

public class AdoDotNetService
{
    public DataTable GetList(string query)
    {
        DataTable data = new DataTable();

        if (query.IsNullOrEmpty())
        {
            return data;
        }

        using (SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
        }

        return data;
    }

    public DataTable GetList(string query, object para)
    {
        DataTable data = new DataTable();

        if (DevCode.IsNull(query))
        {
            return data;
        }

        using (SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(para);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
        }

        return data;
    }

    public int Execute(string query, SqlParameter[] lstPara)
    {
        int result;
        
        if (query.IsNullOrEmpty())
        {
            return 0;
        }

        using (SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(lstPara);        
            result = command.ExecuteNonQuery();
        }

        return result;
    }
}