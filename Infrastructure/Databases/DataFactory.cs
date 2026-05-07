
namespace Infrastructure.Databases;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


internal sealed class DataFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("Server=tcp:mstacksollicitatie.database.windows.net,1433;Initial Catalog=nielsboesten-sqldb;User ID=nielsboesten;Password=sollicitatie123!;Encrypt=True;TrustServerCertificate=False;");

        return new DataContext(optionsBuilder.Options);
    }
}