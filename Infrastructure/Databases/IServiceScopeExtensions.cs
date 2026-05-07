using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Databases;

public static class IServiceScopeExtensions
{
    public static IServiceScope SetupDatabase(this IServiceScope scope, bool addMockData)
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
        dbContext.Database.Migrate();

        if (!dbContext.Products.Any())
        {
            var products = new List<Product>
            {
                new Product { InternalProductId = 1, Name = "McLaren", Description = "Een snelle auto", Price = 100000 },
                new Product { InternalProductId = 2, Name = "Apache", Description = "Een helicopter", Price = 500000 },
                new Product { InternalProductId = 3, Name = "Jacht", Description = "Een boot", Price = 5000000 },
                new Product { InternalProductId = 4, Name = "Gazelle", Description = "Een fiets", Price = 500 },
                new Product { InternalProductId = 5, Name = "Step", Description = "Een step", Price = 20 }
            };

            dbContext.Products.AddRange(products);
            dbContext.SaveChanges();
        }

        var dbProducts = dbContext.Products.ToList();

        if (!dbContext.Orders.Any())
        {
            var orders = new List<Order>
            {
                new Order
                {
                    CustomerName = "Piet Jansen",
                    IsShipped = true,
                    OrderDate = DateTime.Now,
                    Products = dbProducts,
                    TotalOrderPrice = dbProducts.Sum(p => p.Price)
                },
                new Order
                {
                    CustomerName = "Jan Jansen",
                    IsShipped = false,
                    OrderDate = DateTime.Now,
                    Products = new List<Product> { dbProducts[0], dbProducts[0], dbProducts[0] },
                    TotalOrderPrice = dbProducts[0].Price * 3
                },
                new Order
                {
                    CustomerName = "Karel Jansen",
                    IsShipped = false,
                    OrderDate = DateTime.Now,
                    Products = new List<Product> { dbProducts[4], dbProducts[4] },
                    TotalOrderPrice = dbProducts[4].Price * 2
                },
                new Order
                {
                    CustomerName = "Kees Jansen",
                    IsShipped = false,
                    OrderDate = DateTime.Now,
                    Products = new List<Product> { dbProducts[2], dbProducts[3] },
                    TotalOrderPrice = dbProducts[2].Price + dbProducts[3].Price
                }
            };

            dbContext.Orders.AddRange(orders);
            dbContext.SaveChanges();
        }

        if (!dbContext.Shipments.Any())
        {
            var orders = dbContext.Orders.Include(o => o.Products).ToList();

            var shipments = new List<Shipment>
            {
                new Shipment
                {
                    OrderId = orders[0].InternalOrderId,
                    Products = orders[0].Products ?? new List<Product>(),
                    ShipmentAddress = "Stationsstraat 1, Amsterdam",
                    ShipmentDate = DateTime.Now
                },
                new Shipment
                {
                    OrderId = orders[1].InternalOrderId,
                    Products = orders[1].Products ?? new List<Product>(),
                    ShipmentAddress = "Stationsstraat 2, Amsterdam",
                    ShipmentDate = DateTime.Now
                },
                new Shipment
                {
                    OrderId = orders[2].InternalOrderId,
                    Products = orders[2].Products ?? new List<Product>(),
                    ShipmentAddress = "Stationsstraat 3, Amsterdam",
                    ShipmentDate = DateTime.Now
                }
            };

            dbContext.Shipments.AddRange(shipments);
            dbContext.SaveChanges();
        }

        return scope;
    }
}