using Azure.Core;
using System.Reflection.Metadata.Ecma335;
using ZZTicaret.Application.DTO.Basket;
using ZZTicaret.Application.Features.Commands.Basket.AddItemToBasket;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public class BasketService : IBasketService
    {
        public Task AddItemToBasketAsync(BasketItemDTO basketItem)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketItem>> GetBasketItemsAsync()
        {
            throw new NotImplementedException();
        }
    }


}








