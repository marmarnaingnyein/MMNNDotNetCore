using Microsoft.EntityFrameworkCore;
using MMNNDotNetCore.Business;
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