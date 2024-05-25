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
    public DbSet<PizzaExtraModel> PizzaExtras { get; set; }
    public DbSet<PizzaOrderModel> PizzaOrders { get; set; }
    public DbSet<PizzaOrderDetailModel> PizzaOrderDetails { get; set; }
}