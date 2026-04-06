using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Databases;

public class Seed
{
    private readonly DataContext _dataContext;
    public Seed(DataContext context)
    {
        _dataContext = context;
    }

    public void SeedDataContext()
    {
        if (!_dataContext.Products.Any())
        {
            var products = new List<Product>
            {
                new Product { Name = "McLaren", Description = "Een snelle auto", Price = 100000 },
                new Product { Name = "Apache", Description = "Een helicopter", Price = 500000 },
                new Product { Name = "Jacht", Description = "Een boot", Price = 5000000 },
                new Product { Name = "Gazelle", Description = "Een fiets", Price = 500 },
                new Product { Name = "Step", Description = "Een step", Price = 20 }
            };

            _dataContext.Products.AddRange(products);
            _dataContext.SaveChanges();
        }

        var dbProducts = _dataContext.Products.ToList();

        if (!_dataContext.Orders.Any())
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

            _dataContext.Orders.AddRange(orders);
            _dataContext.SaveChanges();
        }

        if (!_dataContext.Shipments.Any())
        {
            var orders = _dataContext.Orders.Include(o => o.Products).ToList();

            var shipments = new List<Shipment>
            {
                new Shipment
                {
                    OrderId = orders[0].OrderId,
                    Products = orders[0].Products,
                    ShipmentAddress = "Stationsstraat 1, Amsterdam",
                    ShipmentDate = DateTime.Now
                },
                new Shipment
                {
                    OrderId = orders[1].OrderId,
                    Products = orders[1].Products,
                    ShipmentAddress = "Stationsstraat 2, Amsterdam",
                    ShipmentDate = DateTime.Now
                },
                new Shipment
                {
                    OrderId = orders[2].OrderId,
                    Products = orders[2].Products,
                    ShipmentAddress = "Stationsstraat 3, Amsterdam",
                    ShipmentDate = DateTime.Now
                }
            };

            _dataContext.Shipments.AddRange(shipments);
            _dataContext.SaveChanges();
        }
    }
}