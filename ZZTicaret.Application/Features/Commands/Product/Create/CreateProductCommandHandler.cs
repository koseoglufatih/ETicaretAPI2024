using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Repositories;

namespace ZZTicaret.Application.Features.Commands.Product.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _productRepository = repository;
        }

       
    

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.AddAsync(new()
            {
                CategoryId = request.CategoryID,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                Id = new Guid()
            });
            await _productRepository.SaveAsync();

            return new ();

        }
    }
}

