using CMS.API.Extensions;
using CMS.BLL.Services.Interface;
using CMS.DAL.DTOS;
using CMS.DAL.Models;
using CMS.DAL.Repository.Interface;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchsController : ControllerBase
    {
        private readonly IGenericService<Branch, BranchDto> _branchService;
        private readonly IValidator<BranchDto> _validator;
        public BranchsController(IGenericService<Branch, BranchDto> branchService, IValidator<BranchDto> validator)
        {
            _branchService = branchService;
            _validator = validator;
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
        public async Task<IActionResult> Create(BranchDto itemDto)
        {

            ValidationResult result = await _validator.ValidateAsync(itemDto);
            if (result.IsValid)
            {
                var responseDto = await _branchService.Add(itemDto);
                return Ok(responseDto);
            }
            else
            {
                result.AddToModelState(this.ModelState);

                return BadRequest(result);
            }

        }
    }
}
