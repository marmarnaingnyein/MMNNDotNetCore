using Microsoft.EntityFrameworkCore;
using MMNNDotNetCore.Models;

namespace MMNNDotNetCore.EFCore.EfAppDbContext;

public class EfAppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogModel> Blogs { get; set; }
    
    public DbSet<PizzaModel> Pizzas { get; set; }
}