using CMS.DAL.Models;
using CMS.DAL.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly IGenericRepository<Merchant> _repository;

        public MerchantsController(IGenericRepository<Merchant> repository)
        {
            _repository = repository;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var merchant = await _repository.Get(Id);

            return Ok(merchant);
        }
        [HttpGet]
        public async Task<List<Merchant>> Get()
        {
            var merchantTask = await _repository.GetAll();
            var merchants = merchantTask.ToList();

            return merchants;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Merchant item)
        {

            var merchantTask = await _repository.Add(item);
            var merchant = merchantTask;

            return Ok(merchant);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid Id, Merchant merchant)
        {

            var entity = await _repository.Get(Id);
            if (entity is null)
            {
                return NotFound();
            }
            entity.Name = merchant.Name;
            entity.Description = merchant.Description;
            entity.TerminalNo = merchant.TerminalNo;
            entity.UpdateDate = DateTime.Now;
            _repository.Update(entity);
            return Ok(entity);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid Id)
        {

            var entity = await _repository.Get(Id);
            if (entity is null)
            {
                return NotFound();
            }
            _repository.Remove(Id);
            return Ok(entity);
        }
    }
}
