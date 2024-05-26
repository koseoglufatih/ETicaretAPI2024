using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.Basket;
using ZZTicaret.Application.Features.Queries.Order.GetOrderById;
using ZZTicaret.Application.Repositories;

namespace ZZTicaret.Application.Features.Queries.Basket.BetBasketByUserId
{
    public class GetBasketByUserIdCommandHandler : IRequestHandler<GetBasketByUserIdCommandRequest, GetBasketByUserIdCommandResponse>
    {

        private readonly IBasketRepository _basketRepository;
        private readonly IBasketItemRepository _basketItemRepository;

        public GetBasketByUserIdCommandHandler(IBasketRepository basketRepository, IBasketItemRepository basketItemRepository)
        {
            _basketRepository = basketRepository;
            _basketItemRepository = basketItemRepository;
        }

        public async Task<GetBasketByUserIdCommandResponse> Handle(GetBasketByUserIdCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.Basket? basket = await _basketRepository.GetByIdAsync(request.UserId);


                //.Include(b => b.User)
                //.Include(u => u.BasketItems)
                //.Where(bi => bi.UserId == request.UserId).FirstOrDefaultAsync();

            if (basket == null)
            {
                return new GetBasketByUserIdCommandResponse
                {
                    ErrorMessage = "Basket bulunamadı."
                };
            }


            decimal totalAmount = 0;

            foreach (var item in basket.BasketItems)
            {

                totalAmount += item.Quantity * item.Product.Price;
            }

            var response = new GetBasketByUserIdCommandResponse()
            {
                BasketId = request.BasketId,
                TotalAmount = totalAmount
            };


            return response;







        }
    }
}
