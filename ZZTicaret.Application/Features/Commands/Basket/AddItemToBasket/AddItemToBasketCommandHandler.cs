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

        private IBasketRepository _basketrepository;

        public AddItemToBasketCommandHandler(IBasketRepository basketrepository)
        {
            _basketrepository = basketrepository;
        }

        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var basket = new Domain.Basket
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                //BasketItems = new List<BasketItem>()
            };

            await _basketrepository.AddAsync(basket);


            //var basketItem = new BasketItem
            //{
            //    Id = Guid.NewGuid(),
            //     ProductId = request.ProductId,
            //     Quantity = request.Quantity,
            //     Basket = basket
                 
            //};

            //basket.BasketItems.Add(basketItem);
            await _basketrepository.SaveAsync();

            return new AddItemToBasketCommandResponse
            {
                Success = true,
                Message = "Ürün Sepete başarılı bir şekilde eklenmiştir."
            };

    }
    }
}
