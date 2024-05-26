using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Features.Commands.Basket.AddItemToBasket;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public interface IBasketItemService
    {

        Task AddItemToBasketAsync(AddItemToBasketCommandRequest request);
        Task<List<BasketItem>> GetBasketByUserIdAsync(Guid userId);

    }
}
