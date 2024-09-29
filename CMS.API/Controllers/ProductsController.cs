using CMS.BLL.Services.Interface;
using CMS.DAL.DTOS;
using CMS.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericService<Product, ProductDto> _productService;
        public ProductsController(IGenericService<Product, ProductDto> productService)
        {
            _productService = productService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _productService.Get(id);

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _productService.GetAll();

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto itemDto)
        {
            var responseDto = await _productService.Add(itemDto);
            return Ok(responseDto);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductDto itemDto)
        {
            var responseDto = await _productService.Update(itemDto);
            return Ok(responseDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _productService.Remove(id);
            return Ok();
        }

    }
}
