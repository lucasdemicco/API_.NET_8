using Domain.Dto;

namespace Services.Interface
{
    public interface ICategoryService
    {
        void createCategory(CategoryDto category);
        void updateCategory(CategoryDto category, int id);
    }
}
