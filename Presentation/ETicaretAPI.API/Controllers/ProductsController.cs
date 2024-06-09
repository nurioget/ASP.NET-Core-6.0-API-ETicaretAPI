
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWiriteRepository  _productWiriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWiriteRepository productWiriteRepository, IProductReadRepository productReadRepository)
        {
            _productWiriteRepository = productWiriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_productReadRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id,false));

        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            await _productWiriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
            });
            await _productWiriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product=await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;
            await _productWiriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWiriteRepository.RemoveAsync(id);
            await _productWiriteRepository.SaveAsync();
            return Ok();
        }
    }
} 
