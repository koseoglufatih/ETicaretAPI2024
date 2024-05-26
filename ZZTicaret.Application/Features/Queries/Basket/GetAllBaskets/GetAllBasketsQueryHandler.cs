using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.Basket;
using ZZTicaret.Application.DTO.User;
using ZZTicaret.Application.Repositories;

namespace ZZTicaret.Application.Features.Queries.Basket.GetAllBaskets
{
    public class GetAllBasketsQueryHandler : IRequestHandler<GetAllBasketsQueryRequest, GetAllBasketsQueryResponse>
    {
        readonly IBasketRepository _basketRepository;

        public GetAllBasketsQueryHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<GetAllBasketsQueryResponse> Handle(GetAllBasketsQueryRequest request, CancellationToken cancellationToken)
        {
            var baskets = await _basketRepository.GetAllAsync();

            var basketDtos = baskets.Select(b => new BasketDto
            {
                UserId = b.UserId,
                BasketItems = b.BasketItems.Select(i => new BasketItemDTO
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList(),
                User = new UserDto
                {
                    NameSurname = b.User.NameSurname,
                    Email = b.User.Email
                }
            }).ToList();

            return new GetAllBasketsQueryResponse()
            {
                Baskets = basketDtos
            };
        }
    }
}
