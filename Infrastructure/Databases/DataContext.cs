using Microsoft.EntityFrameworkCore;
using Domain2;

namespace Infrastructure.Databases;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<Order> Orders { get; set; }
}