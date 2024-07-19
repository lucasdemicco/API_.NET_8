using Domain.Dto;
using Domain.Entity;
using Infrastructure.Repository.Interface;

namespace Infrastructure.Repository.Service
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateProduct(ProductDto product)
        {
            Product entity = new()
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                RegistrationDate = DateTime.Now
            };

            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public IList<Product> findAll()
            => _context.Products.ToList();
    }
}
