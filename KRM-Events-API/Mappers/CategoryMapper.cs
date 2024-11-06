using KRM_Events_API.Dtos.Category;
using KRM_Events_API.Model;

namespace KRM_Events_API.Mappers
{
    public static class CategoryMapper
    {
       public static CategoryDTO ToCategoryDTO(this Category category)
       {
            return new CategoryDTO
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                Image = category.Image,
                Events = category.Events,
            };
       }
        public static Category ToCategoryFromCreateDto(this CreateCategoryDTO category) {

            return new Category
            {
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                Image = category.Image,
            };
        }
    }
}
