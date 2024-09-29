using CMS.BLL.Services.Interface;
using CMS.DAL.DTOS;
using CMS.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IGenericService<Category, CategoryDto> _categoryService;
        public CategoriesController(IGenericService<Category, CategoryDto> categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _categoryService.Get(id);

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.GetAll();

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto itemDto)
        {
            var responseDto = await _categoryService.Add(itemDto);
            return Ok(responseDto);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto itemDto)
        {
            var responseDto = await _categoryService.Update(itemDto);
            return Ok(responseDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _categoryService.Remove(id);
            return Ok();
        }

    }
}
