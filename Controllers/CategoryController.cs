using biblioteca_fc_api.Models;
using biblioteca_fc_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca_fc_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult<List<CategoryModel>>> CreateCategory([FromBody] CategoryModel category)
        {
            List<CategoryModel> categories = await _categoryRepository.CreateCategory(category);
            return Ok(categories);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> FindAllCategorys()
        {
            List<CategoryModel> categories = await _categoryRepository.FindAllCategorys();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> FindCategoryById(int id)
        {
            CategoryModel category = await _categoryRepository.FindCategoryById(id);
            if (category == null)
            {
                return BadRequest("Category not foud!");
            }
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryModel>> UpdatCategory([FromBody] CategoryModel categoryModel, int id)
        {
            var category = await _categoryRepository.FindCategoryById(id);
            if (category == null)
            {
                return BadRequest("Category not foud!");
            }
            categoryModel.Id = id;
            CategoryModel newCategoryData = await _categoryRepository.UpdateCategory(categoryModel, id);
            return Ok(newCategoryData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryModel>> RemoveCategory(int id)
        {
            var category = await _categoryRepository.FindCategoryById(id);
            if (category == null)
            {
                return BadRequest("User not foud!");
            }

            bool isRemoved = await _categoryRepository.RemoveCategory(id);
            if (!isRemoved)
            {
                return BadRequest("User not foud!");
            }

            return NoContent();
        }
    }
}