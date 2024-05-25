using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.Basket;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public interface IBasketService
    {

        public Task<List<BasketItem>> GetBasketItemsAsync();
        public Task AddItemToBasketAsync(BasketItemDTO basketItem);

    }
}

