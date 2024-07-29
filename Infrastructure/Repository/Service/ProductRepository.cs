using Domain.Dto;
using Domain.Entity;
using Infrastructure.Repository.Interface;
using Infrastructure.UOW.Interface;

namespace Infrastructure.Repository.Service
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _uow;

        public ProductRepository(ApplicationDbContext context, IUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
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
            _uow.Commit();
        }

        public IList<Product> findAll()
            => _context.Products.ToList();
    }
}
