using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.Basket;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public interface IBasketService
    {

        Task AddProductToBasket(Guid userId, Guid productId, int Quantity);
        Task<decimal> GetBasketTotal(Guid UserId);
        Task RemoveProductFromBasket(Guid userId, Guid productId);
        Task ClearBasket(Guid userId);
        Task<List<Create_BasketItem>> GetBasketItems(Guid userId);
    }

}