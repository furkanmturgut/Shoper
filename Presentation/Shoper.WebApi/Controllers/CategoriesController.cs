using Microsoft.AspNetCore.Mvc;
using Shoper.Appplication.Dtos.CategoryDto;
using Shoper.Appplication.Usecasess.CategoryService;

namespace Shoper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoriesService;

        public CategoriesController(ICategoryServices categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categoires = await _categoriesService.GetAllCategoryAsync();
            return Ok(categoires);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            var category = await _categoriesService.GetByIdCategoryAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
             await _categoriesService.CreateCategoryAsync(dto);
             return Ok("Kategori başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            await _categoriesService.UpdateCategoryAsync(dto);
            return Ok("Kategori başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoriesService.DeleteCategoryAsync(id);
            return Ok("Kategori başarıyla silindi");
        }
    }
}
