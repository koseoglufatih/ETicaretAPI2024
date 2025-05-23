﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Features.Commands.Basket.AddItemToBasket
{


    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
    {
        readonly IBasketRepository _basketRepository;
        readonly IBasketItemRepository _basketitemRepository;

        public AddItemToBasketCommandHandler(IBasketRepository basketRepository, IBasketItemRepository basketitemRepository)
        {
            _basketRepository = basketRepository;
            _basketitemRepository = basketitemRepository;
        }

        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new AddItemToBasketCommandResponse();

           
            var basket = new Domain.Basket
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                BasketItems = new List<BasketItem>()
            };

            await _basketRepository.AddAsync(basket);
            await _basketRepository.SaveAsync();

            // Yeni bir sepet öğesi oluştur
            var basketItem = new BasketItem
            {
                Id = Guid.NewGuid(), 
                BasketId = basket.Id, 
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Price = request.Price
            };

            await _basketitemRepository.AddAsync(basketItem);
            await _basketitemRepository.SaveAsync();

            response.Success = true;
            response.Message = "Item added to basket successfully.";

            return response;




        }
    }
}





