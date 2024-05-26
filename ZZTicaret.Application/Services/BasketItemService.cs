using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Features.Commands.Basket.AddItemToBasket;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public class BasketItemService : IBasketItemService
    {

        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IBasketRepository _basketRepository;


        public BasketItemService(IBasketItemRepository basketItemRepository, IBasketRepository basketRepository)
        {
            _basketItemRepository = basketItemRepository;
            _basketRepository = basketRepository;
        }

        public async Task AddItemToBasketAsync(AddItemToBasketCommandRequest request)
        {
            var basket = await _basketRepository.GetByIdAsync(request.UserId);
            if (basket == null)
            {
                basket = new Domain.Basket
                {
                    UserId = request.UserId,
                    BasketItems = new List<BasketItem>()
                };
                await _basketRepository.AddAsync(basket);
            }

            var basketItem = new Domain.BasketItem
            {
                BasketId = basket.Id,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Price = request.Price,
            };
          await _basketItemRepository.AddAsync(basketItem);
        }

        public async Task<List<BasketItem>> GetBasketByUserIdAsync(Guid userId)
        {
            return await _basketItemRepository.GetBasketByUserIdAsync(userId);
        }
    }
}
