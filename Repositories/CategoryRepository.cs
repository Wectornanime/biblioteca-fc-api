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

        public Task<List<CategoryModel>> CreateCategory(CategoryModel category)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryModel>> FindAllCategorys()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> FindCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> UpdateCategory(CategoryModel category, int id)
        {
            throw new NotImplementedException();
        }
        
        public Task<bool> RemoveCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}