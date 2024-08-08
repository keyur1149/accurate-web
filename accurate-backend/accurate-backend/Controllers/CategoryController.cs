using accurate_data_access.DTO;
using accurate_data_access.Entities;
using accurate_services.services;
using Microsoft.AspNetCore.Mvc;

namespace accurate_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService productService)
        {
            _categoryService = productService;
        }

        /// <summary>
        /// Get All Category .
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIResponse<List<CategoryTbl>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse<List<CategoryTbl>>), StatusCodes.Status500InternalServerError)]
        public async Task<APIResponse<List<CategoryTbl>>> GetCategories()
        {
            return await _categoryService.FetchAllCategories();
        }

        /// <summary>
        ///  Add Category
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<APIResponse<string>> AddCategory(AddCategoryDTOs category)
        {
            return await _categoryService.AddCategoryAsync(category);
        }
        /// <summary>
        ///  Edit Category
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="Category"></param>
        /// <returns></returns>
        [HttpPut("{categoryId:long}")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<APIResponse<string>> EditCategory(long categoryId,EditCategoryDTOs category)
        {
            return await _categoryService.EditCategoryAsync(categoryId,category);
        }
        /// <summary>
        ///  Delete Category
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        [HttpDelete("{categoryId:long}")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<APIResponse<string>> DeleteCategory(long categoryId)
        {
            return await _categoryService.RemoveCategoryAsync(categoryId);
        }
    }
}
