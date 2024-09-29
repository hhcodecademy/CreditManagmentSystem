using CMS.API.Extensions;
using CMS.BLL.Services.Interface;
using CMS.DAL.DTOS;
using CMS.DAL.Models;
using CMS.DAL.Repository.Interface;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchsController : ControllerBase
    {
        private readonly IGenericService<Branch, BranchDto> _branchService;
        private readonly ILogger<BranchsController> _logger;
        public BranchsController(IGenericService<Branch, BranchDto> branchService, ILogger<BranchsController> logger)
        {
            _branchService = branchService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _branchService.Get(id);
            _logger.LogInformation($"Id: {id} get request");

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

          
                var responseDto = await _branchService.Add(itemDto);
                return Ok(responseDto);
           

        }
    }
}
