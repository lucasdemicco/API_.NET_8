using Domain.Dto;
using Domain.Entity;

namespace Infrastructure.Repository.Interface
{
    public interface IProductRepository
    {
        IList<Product> findAll();
        void CreateProduct(ProductDto product);
    }
}
