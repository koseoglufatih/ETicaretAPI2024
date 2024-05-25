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

        public GetBasketByUserIdCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<GetBasketByUserIdCommandResponse> Handle(GetBasketByUserIdCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.Basket? basket = await _basketRepository._dbSet
                .Include(b => b.User)
                .Include(u => u.BasketItems)
                .Where(bi => bi.UserId == request.UserId).FirstOrDefaultAsync();

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
