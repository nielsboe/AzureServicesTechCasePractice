using Microsoft.EntityFrameworkCore;

namespace AzureServiceBusQueue.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
