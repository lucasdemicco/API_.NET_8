using Domain.Dto;
using Domain.Entity;
using Infrastructure.Repository.Interface;
using Services.Interface;

namespace Services.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void createProduct(ProductDto product)
            => _productRepository.CreateProduct(product);

        public IList<Product> findAll()
            => _productRepository.findAll();
    }
}
