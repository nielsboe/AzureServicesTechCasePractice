using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Infrastructure.Databases;

namespace Tests.Infrastructure
{
    public class IServiceCollectionExtensionsTests
    {
        [Fact]
        public void RegisterDatabaseRepositories_RegistersExpectedServices()
        {
            // Arrange
            var inMemoryConfig = new ConfigurationBuilder()
                .AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>($"{DatabaseOptions.SectionName}:ConnectionString", "Server=(local);Database=Test;Trusted_Connection=True;")
                })
                .Build();

            var services = new ServiceCollection();

            // Act
            services.RegisterDatabaseRepositories(inMemoryConfig);

            // Assert: repository registrations exist
            var hasOrderRepo = services.Any(sd => sd.ServiceType.FullName?.Contains("IOrderRepository") == true);
            var hasProductRepo = services.Any(sd => sd.ServiceType.FullName?.Contains("IProductRepository") == true);
            var hasShipmentRepo = services.Any(sd => sd.ServiceType.FullName?.Contains("IShipmentRepository") == true);

            Assert.True(hasOrderRepo, "IOrderRepository should be registered.");
            Assert.True(hasProductRepo, "IProductRepository should be registered.");
            Assert.True(hasShipmentRepo, "IShipmentRepository should be registered.");

            // Assert: DatabaseOptions configured
            var hasOptions = services.Any(sd => sd.ServiceType.FullName?.Contains("IOptions`1") == true && sd.ImplementationType == null);
            Assert.True(hasOptions, "DatabaseOptions should be configured via Options pattern.");
        }
    }
}