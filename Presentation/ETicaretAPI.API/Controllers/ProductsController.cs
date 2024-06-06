
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task  Get()
        {
            //await _productWiriteRepository.AddRangeAsync(new()
            //{
            //     new() { Id=Guid.NewGuid(),Name="Product 1",Price=100,CreateDate=DateTime.UtcNow,Stock=10},
            //     new() { Id=Guid.NewGuid(),Name="Product 2",Price=234,CreateDate=DateTime.UtcNow,Stock=23},
            //     new() { Id=Guid.NewGuid(),Name="Product 3",Price=5432,CreateDate=DateTime.UtcNow,Stock=34}
            //});
            //await _productWiriteRepository.SaveAsync();

            Product p = await _productReadRepository.GetByIdAsync("a94ef99f-06b5-411d-8203-d1c3b1fbdf22",false);
            p.Name = "mehmet";
            await _productWiriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
