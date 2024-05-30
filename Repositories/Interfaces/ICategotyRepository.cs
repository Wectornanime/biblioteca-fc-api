using biblioteca_fc_api.Models;

namespace biblioteca_fc_api.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> FindAllCategorys();
        Task<CategoryModel> FindCategoryById(int id);
        Task<List<CategoryModel>> CreateCategory(CategoryModel category);
        Task<CategoryModel> UpdateCategory(CategoryModel category, int id);
        Task<bool> RemoveCategory(int id);
    }
}