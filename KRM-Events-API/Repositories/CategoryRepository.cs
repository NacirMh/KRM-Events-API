using KRM_Events_API.Data;
using KRM_Events_API.Dtos.Category;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace KRM_Events_API.Repositories
{
    public class CategoryRepository : ICategoryRepository
     {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Category?> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) { 
               return null;
            }
            return category;
        }
        public async Task<bool> CategoryExists(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return false;
            }
            return true;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategory(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) {
                return null;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> UpdateCategory(int id, UpdateCategory category)
        {
            if (! await CategoryExists(id))
            {
               return null;
            }
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.CategoryDescription = category.CategoryDescription;
            existingCategory.Image = category.Image;    
            await _context.SaveChangesAsync();
            return existingCategory;
        }
    }
}
