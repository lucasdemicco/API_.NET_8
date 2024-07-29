using Domain.Dto;

namespace Infrastructure.Repository.Interface
{
    public interface ICategoryRepository
    {
        void create(CategoryDto category);
        void updateCategory(CategoryDto category, int id);
    }
}
