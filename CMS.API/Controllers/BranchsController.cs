using CMS.BLL.Services.Interface;
using CMS.DAL.DTOS;
using CMS.DAL.Models;
using CMS.DAL.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchsController : ControllerBase
    {
        private readonly IGenericService<Branch, BranchDto> _branchService;

        public BranchsController(IGenericService<Branch, BranchDto> branchService)
        {
            _branchService = branchService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _branchService.Get(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _branchService.GetAll();

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BranchDto dto)
        {

            return Ok(dto);
        }
    }
}
