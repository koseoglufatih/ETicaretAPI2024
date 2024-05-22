using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Application.Services;

namespace ZZTicaret.Application.Features.Commands.Basket.AddProductToBasket
{
    public class AddProductToBasketCommandHandler : IRequestHandler<AddProductToBasketCommandRequest, AddProductToBasketCommandResponse>
    {

        private readonly IProductRepository _productRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IUserRepository _userRepository;

        public AddProductToBasketCommandHandler(IBasketRepository basketRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<AddProductToBasketCommandResponse> Handle(AddProductToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                throw new Exception("Ürün bulunamadı");
            }

            var basket = _basketRepository._dbSet.FirstOrDefault(b => b.UserId == request.UserId);
            if (basket == null)
            {
                basket = new Domain.Basket { UserId = request.UserId };
                await _basketRepository.AddAsync(basket);
            }

            var basketItem = basket.BasketItems.FirstOrDefault(bi => bi.ProductId == request.ProductId);
            if (basketItem == null)
            {
                basketItem = new Domain.BasketItem
                {
                    BasketId = basket.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                };
                basket.BasketItems.Add(basketItem);  
            }

            else
            {
                basketItem.Quantity += request.Quantity;
            }

            await _basketRepository.SaveAsync();

            return new();
             


        }
    }

}
