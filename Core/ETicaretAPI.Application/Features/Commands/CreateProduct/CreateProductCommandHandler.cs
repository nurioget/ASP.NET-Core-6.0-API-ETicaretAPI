using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWiriteRepository _productWiriteRepository;

        public CreateProductCommandHandler(IProductWiriteRepository wiriteRepository)
        {
            _productWiriteRepository = wiriteRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWiriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
            });
            await _productWiriteRepository.SaveAsync();
            return new CreateProductCommandResponse();
        }
    }
}
