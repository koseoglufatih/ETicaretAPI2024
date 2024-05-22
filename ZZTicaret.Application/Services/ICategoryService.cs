using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public interface ICategoryService
    {
        Task <Category> GetCategoryByIdAsync(Guid categoryId);
        Task<List<Category>> GetAllCategories();
        Task CreateCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Guid categoryId);
        
      
    }
}
