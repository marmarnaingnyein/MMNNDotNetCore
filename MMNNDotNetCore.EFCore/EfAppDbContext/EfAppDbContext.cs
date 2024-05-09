using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MMNNDotNetCore.Models;

namespace MMNNDotNetCore.EFCore.EfAppDbContext;

public class EfAppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogModel> Blogs { get; set; }
}