using Microsoft.EntityFrameworkCore;
using MMNNDotNetCore.ConsoleApp.Service;

namespace MMNNDotNetCore.EFCore.EfAppDbContext;

public class EfAppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

}