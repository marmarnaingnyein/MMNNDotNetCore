using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MMNNDotNetCore.ConsoleApp.Service;

namespace MMNNDotNetCore.ConsoleApp.DbService;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogModel> Blogs { get; set; }
}