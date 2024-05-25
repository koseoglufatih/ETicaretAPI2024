using Azure.Core;
using System.Reflection.Metadata.Ecma335;
using ZZTicaret.Application.DTO.Basket;
using ZZTicaret.Application.Features.Commands.Basket.AddItemToBasket;
using ZZTicaret.Application.Features.Queries.Basket.GetAllBaskets;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
   
    public class BasketService : IBasketService
    {
        readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<AddItemToBasketCommandResponse> AddItemToBasket(Guid UserId)
        {
            await _basketRepository.AddItemToBasket(UserId);
            await _basketRepository.SaveAsync();
            return new AddItemToBasketCommandResponse();
        }

        public async Task<GetAllBasketsQueryResponse> GetAllBaskets()
        {
            await _basketRepository.GetAllBaskets();
            return new GetAllBasketsQueryResponse();
        }
    }


}








