using Domain.Dto;
using Domain.Entity;

namespace Services.Interface
{
    public interface IProductService
    {
        IList<Product> findAll();
        void createProduct(ProductDto product);
    }
}
