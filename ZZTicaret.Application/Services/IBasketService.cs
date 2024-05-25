using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.Basket;
using ZZTicaret.Application.Features.Commands.Basket.AddItemToBasket;
using ZZTicaret.Application.Features.Queries.Basket.GetAllBaskets;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public interface IBasketService
    {

        Task<GetAllBasketsQueryResponse> GetAllBaskets();
        Task<AddItemToBasketCommandResponse> AddItemToBasket(Guid UserId);

    }
}

