using CMS.API.Extensions;
using CMS.BLL.Services.Interface;
using CMS.DAL.DTOS;
using CMS.DAL.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IGenericService<Employee,EmployeeDto> _employeeService;
        public EmployeesController(IGenericService<Employee, EmployeeDto> employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _employeeService.Get(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeService.GetAll();

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto dto)
        {

           
                var res = await _employeeService.Add(dto);
                return Ok(res);
            
       
        }
    }
}
