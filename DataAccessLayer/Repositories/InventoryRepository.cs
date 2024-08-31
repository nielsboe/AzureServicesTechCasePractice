using DataAccessLayer.Interfaces;
using DataAccessLayer.Data;
using Domain;
using MapsterMapper;

namespace DataAccessLayer.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapsterMapper;

        public InventoryRepository(DataContext context, IMapper mapsterMapper)
        {
            _mapsterMapper = mapsterMapper;
            _context = context;
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.Id).ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool CreateProduct(ProductDTO productDto)
        {
            var product = _mapsterMapper.Map<Product>(productDto);
            _context.Products.Add(product);
            return Save();
        }

        public bool UpdateProduct(ProductDTO productDto)
        {
            var product = _mapsterMapper.Map<Product>(productDto);
            _context.Products.Update(product);
            return Save();
        }

        public bool DeleteProduct(ProductDTO productDto)
        {
            var product = _mapsterMapper.Map<Product>(productDto);
            _context.Products.Remove(product);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
