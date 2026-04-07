
namespace Infrastructure.Databases;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


internal sealed class CirliFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("");

        return new DataContext(optionsBuilder.Options);
    }
}