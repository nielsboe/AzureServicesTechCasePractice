using Domain2;
using Domain2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2;

public class ProductHandler(IProductRepository inventoryRepository, ILogger<ProductHandler> logger) : IProductHandler
{
    private readonly IProductRepository _inventoryRepository = inventoryRepository;

    public async Task<int> CreateProduct(Product product, CancellationToken cancellationToken)
    {

        await _inventoryRepository.Create(product, cancellationToken);


    }


}
