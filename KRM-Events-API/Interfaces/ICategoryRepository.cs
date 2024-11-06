using KRM_Events_API.Dtos.Category;
using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAll();
        public Task<Category> GetCategoryById(int id);

        public Task<Category> CreateCategory(Category category);

        public Task<Category?> UpdateCategory(int id, UpdateCategory category);

        public Task<Category?> DeleteCategory(int id);

        public Task<bool> CategoryExists(int id);

       
    }
}
