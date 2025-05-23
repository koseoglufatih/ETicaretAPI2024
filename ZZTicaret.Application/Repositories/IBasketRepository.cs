﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Features.Commands.Basket.AddItemToBasket;
using ZZTicaret.Application.Features.Queries.Basket.GetAllBaskets;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Repositories
{

    public interface IBasketRepository : IRepository<Basket>
    {
       
        Task<GetAllBasketsQueryResponse> GetAllBaskets();
        Task<AddItemToBasketCommandResponse> AddItemToBasket(Guid UserId);
        Task<Basket> GetByIdAsync(Guid userId);



    }
}
