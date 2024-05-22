using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Features.Commands.Category.Update;
using ZZTicaret.Application.Repositories;

namespace ZZTicaret.Application.Features.Commands.Product.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ZZTicaret.Domain.Product products = await _productRepository.GetByIdAsync(request.Id);
            products.Stock = request.Stock;
            products.Price = request.Price;
            products.Name = request.Name;
            await _productRepository.SaveAsync();
            return new ();

        }
    }
}
