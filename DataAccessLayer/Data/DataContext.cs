using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;
using ShippingAPI.Models;

namespace DataAccessLayer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
