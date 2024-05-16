using biblioteca_fc_api.Data;
using biblioteca_fc_api.Models;
using biblioteca_fc_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_fc_api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BibiotecaDbContext _dbContext;
        public CategoryRepository(BibiotecaDbContext bibiotecaDbContext)
        {
            _dbContext = bibiotecaDbContext;
        }

        public async Task<List<CategoryModel>> CreateCategory(CategoryModel category)
        {
            await _dbContext.Categorys.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Categorys.ToListAsync();;
        }

        public async Task<List<CategoryModel>> FindAllCategorys()
        {
            return await _dbContext.Categorys.ToListAsync();
        }

        public async Task<CategoryModel> FindCategoryById(int id)
        {
            return await _dbContext.Categorys.FindAsync(id);
        }

        public async Task<CategoryModel> UpdateCategory(CategoryModel category, int id)
        {
            CategoryModel categoryData = await FindCategoryById(id);

            if (categoryData == null)
            {
                throw new Exception("Book not foud!");
            }

            categoryData.Name = category.Name;

            _dbContext.Categorys.Update(categoryData);
            await _dbContext.SaveChangesAsync();

            return categoryData;
        }
        
        public async Task<bool> RemoveCategory(int id)
        {
            var category = await _dbContext.Categorys.FindAsync(id);
            if (category == null)
            {
                throw new Exception("Category not foud!");
            }
            _dbContext.Categorys.Remove(category);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}