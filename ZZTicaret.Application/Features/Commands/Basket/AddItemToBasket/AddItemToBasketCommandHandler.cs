using MediatR;
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

        public AddItemToBasketCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new AddItemToBasketCommandResponse();

           
                var basket = await _basketRepository.GetByIdAsync(request.UserId);
                if (basket == null)
                {
                    basket = new Domain.Basket
                    {
                        Id = Guid.NewGuid(),
                        UserId = request.UserId,
                        BasketItems = new List<BasketItem>()
                    };
                }

                await _basketRepository.AddAsync(basket);
             


                var basketItems = new BasketItem
                {
                    Id = basket.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                     
                };

              

                response.Success = true;
                response.Message = "Item added to basket successfully.";

 

            return response;

        }
    }
}





