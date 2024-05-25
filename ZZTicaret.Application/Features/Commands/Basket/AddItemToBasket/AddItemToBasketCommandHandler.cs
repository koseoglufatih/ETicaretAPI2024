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

            try
            {
                var basket = await _basketRepository.GetByIdAsync(request.UserId);
                if (basket == null)
                {
                    basket = new Domain.Basket
                    {
                        UserId = request.UserId,
                        BasketItems = new List<BasketItem>()
                    };
                }

                await _basketRepository.AddAsync(basket);
                await _basketRepository.SaveAsync();

                var basketItems = new BasketItem
                {
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,

                };        


                response.Success = true;
                response.Message = "Item added to basket successfully.";

              

            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;

        }
    }
}





