
using ETicaretAPI.Application.Repositories;
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
        public async void Get()
        {
           await _productWiriteRepository.AddRangeAsync(new()
            {
                new() { Id=Guid.NewGuid(),Name="Product 1",Price=100,CreateDate=DateTime.UtcNow,Stock=10},
                new() { Id=Guid.NewGuid(),Name="Product 2",Price=234,CreateDate=DateTime.UtcNow,Stock=23},
                new() { Id=Guid.NewGuid(),Name="Product 3",Price=5432,CreateDate=DateTime.UtcNow,Stock=34}
                });
           await _productWiriteRepository.SaveAsync();
        }
    }
}
