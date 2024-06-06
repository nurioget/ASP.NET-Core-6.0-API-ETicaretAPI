
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

        private readonly IOrderWiriteRepository _orderWiriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        private readonly ICustomerWiriteRepository _customerWiriteRepository;

        public ProductsController(IProductWiriteRepository productWiriteRepository, IProductReadRepository productReadRepository, IOrderWiriteRepository orderWiriteRepository, IOrderReadRepository orderReadRepository, ICustomerWiriteRepository customerWiriteRepository)
        {
            _productWiriteRepository = productWiriteRepository;
            _productReadRepository = productReadRepository;
            _orderWiriteRepository = orderWiriteRepository;
            _orderReadRepository = orderReadRepository;
            _customerWiriteRepository = customerWiriteRepository;
        }

        [HttpGet]
        public async Task  Get()
        {
            Order order = await _orderReadRepository.GetByIdAsync("e9ba3b86-2164-452b-96f3-9f5cb14429f9");
            order.Address = "mardin";
            await _orderWiriteRepository.SaveAsync();
        }


    }
} 
