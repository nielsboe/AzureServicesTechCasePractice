using DataAccessLayer.Data;
using Domain;

namespace DataAccessLayer
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Shipments.Any())
            {
                var shipments = new List<Shipment>()
                {
                    new Shipment()
                    {
                        Products = new List<Product>
                        {
                            new Product()
                            {
                                ProductId = 1,
                                Description = "Een snelle auto",
                                Name = "McLaren",
                                Price = 100000,
                            },
                            new Product()
                            {
                                ProductId = 2,
                                Description = "Een helicopter",
                                Name = "Apache",
                                Price = 500000,
                            },
                            new Product()
                            {
                                ProductId = 3,
                                Description = "Een boot",
                                Name = "Jacht",
                                Price = 5000000,
                            },
                            new Product()
                            {
                                ProductId = 4,
                                Description = "Een fiets",
                                Name = "Gazelle",
                                Price = 500,
                            },
                            new Product()
                            {
                                ProductId = 5,
                                Description = "Een step",
                                Name = "Step",
                                Price = 20,
                            }
                        },
                        OrderId = 1,
                        ShipmentAddress = "Stationsstraat 1, 1234AB, Amsterdam",
                        ShipmentDate = DateTime.Now,
                        ShipmentId = 1
                    },
                    new Shipment()
                    {
                        Products = new List<Product>
                        {
                            new Product()
                            {
                                ProductId = 1,
                                Description = "Een snelle auto",
                                Name = "McLaren",
                                Price = 100000,
                            },
                            new Product()
                            {
                                ProductId = 1,
                                Description = "Een snelle auto",
                                Name = "McLaren",
                                Price = 100000,
                            },
                            new Product()
                            {
                                ProductId = 1,
                                Description = "Een snelle auto",
                                Name = "McLaren",
                                Price = 100000,
                            },
                            new Product()
                            {
                                ProductId = 1,
                                Description = "Een snelle auto",
                                Name = "McLaren",
                                Price = 100000,
                            },
                            new Product()
                            {
                                ProductId = 1,
                                Description = "Een snelle auto",
                                Name = "McLaren",
                                Price = 100000,
                            }
                        },
                        OrderId = 2,
                        ShipmentAddress = "Stationsstraat 2, 1234AC, Amsterdam",
                        ShipmentDate = DateTime.Now,
                        ShipmentId = 2
                    },
                    new Shipment()
                    {
                        Products = new List<Product>
                        {
                            new Product()
                            {
                                ProductId = 5,
                                Description = "Een step",
                                Name = "Step",
                                Price = 20,
                            },
                            new Product()
                            {
                                ProductId = 5,
                                Description = "Een step",
                                Name = "Step",
                                Price = 20,
                            },
                            new Product()
                            {
                                ProductId = 5,
                                Description = "Een step",
                                Name = "Step",
                                Price = 20,
                            },
                            new Product()
                            {
                                ProductId = 5,
                                Description = "Een step",
                                Name = "Step",
                                Price = 20,
                            },
                            new Product()
                            {
                                ProductId = 5,
                                Description = "Een step",
                                Name = "Step",
                                Price = 20,
                            },
                        },
                        OrderId = 3,
                        ShipmentAddress = "Stationsstraat 3, 1234AD, Amsterdam",
                        ShipmentDate = DateTime.Now,
                        ShipmentId = 3
                    }
                };
                dataContext.Shipments.AddRange(shipments);
            }
            if (!dataContext.Orders.Any())
            {
                var orders = new List<Order>()
                {
                    new Order()
                    {
                        CustomerName = "Piet Jansen",
                        IsShipped = true,
                        OrderDate = DateTime.Now,
                        OrderId = 1,
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                ProductId = 1,
                                Description = "Een snelle auto",
                                Name = "McLaren",
                                Price = 100000,
                            },
                            new Product()
                            {
                                ProductId = 2,
                                Description = "Een helicopter",
                                Name = "Apache",
                                Price = 500000,
                            },
                            new Product()
                            {
                                ProductId = 3,
                                Description = "Een boot",
                                Name = "Jacht",
                                Price = 5000000,
                            },
                            new Product()
                            {
                                ProductId = 4,
                                Description = "Een fiets",
                                Name = "Gazelle",
                                Price = 500,
                            },
                            new Product()
                            {
                                ProductId = 5,
                                Description = "Een step",
                                Name = "Step",
                                Price = 20,
                            }
                        },
                        TotalOrderPrice = 5600520
                    },
                    new Order()
                    {
                        CustomerName = "Jan Jansen",
                        IsShipped = false,
                        OrderDate = DateTime.Now,
                        OrderId = 2,
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                ProductId = 1,
                                Description = "Een snelle auto",
                                Name = "McLaren",
                                Price = 100000,
                            },
                            new Product()
                            {
                                ProductId = 1,
                                Description = "Een snelle auto",
                                Name = "McLaren",
                                Price = 100000,
                            },
                            new Product()
                            {
                                ProductId = 1,
                                Description = "Een snelle auto",
                                Name = "McLaren",
                                Price = 100000,
                            },
                            new Product()
                            {
                                ProductId = 1,
                                Description = "Een snelle auto",
                                Name = "McLaren",
                                Price = 100000,
                            },
                            new Product()
                            {
                                ProductId = 1,
                                Description = "Een snelle auto",
                                Name = "McLaren",
                                Price = 100000,
                            }
                        },
                        TotalOrderPrice = 500000
                    },
                    new Order()
                    {
                        CustomerName = "Karel Jansen",
                        IsShipped = false,
                        OrderDate = DateTime.Now,
                        OrderId = 3,
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                ProductId = 5,
                                Description = "Een step",
                                Name = "Step",
                                Price = 20,
                            },
                            new Product()
                            {
                                ProductId = 5,
                                Description = "Een step",
                                Name = "Step",
                                Price = 20,
                            },
                            new Product()
                            {
                                ProductId = 5,
                                Description = "Een step",
                                Name = "Step",
                                Price = 20,
                            },
                            new Product()
                            {
                                ProductId = 5,
                                Description = "Een step",
                                Name = "Step",
                                Price = 20,
                            },
                            new Product()
                            {
                                ProductId = 5,
                                Description = "Een step",
                                Name = "Step",
                                Price = 20,
                            },
                        },
                        TotalOrderPrice = 100
                    },
                    new Order()
                    {
                        CustomerName = "Kees Jansen",
                        IsShipped = false,
                        OrderDate = DateTime.Now,
                        OrderId = 4,
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                ProductId = 3,
                                Description = "Een boot",
                                Name = "Jacht",
                                Price = 5000000,
                            },
                            new Product()
                            {
                                ProductId = 4,
                                Description = "Een fiets",
                                Name = "Gazelle",
                                Price = 500,
                            },
                        },
                        TotalOrderPrice = 5000500
                    }
                };

                dataContext.Orders.AddRange(orders);
            }
            dataContext.SaveChanges();
        }
    }
}