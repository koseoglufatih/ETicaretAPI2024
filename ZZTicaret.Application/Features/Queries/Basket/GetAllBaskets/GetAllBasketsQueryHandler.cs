using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.Basket;
using ZZTicaret.Application.DTO.User;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

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

            if (baskets == null)
            {
                throw new BasketNotFoundException();
            }

            var basketDtos = baskets.Select(b =>
            {
                if (b.BasketItems == null)
                {
                    Console.WriteLine($"Kullanıcıya ait {b.UserId} basketitem bulunamadı.");
                }

                if (b.User == null)
                {
                    Console.WriteLine($"Sepete ait {b.UserId} kullanıcı bulunamadı.");
                }

                return new BasketDto
                {

                    UserId = b.UserId,
                    BasketItems = b.BasketItems?.Select(i => new BasketItemDTO
                    {
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                        Price = i.Price
                    }).ToList() ?? new List<BasketItemDTO>(),

                    User = b.User != null ? new UserDto
                    {
                        NameSurname = b.User.NameSurname,
                        Email = b.User.Email
                    } : null
                };
            }).ToList();

            return new GetAllBasketsQueryResponse()
            {
                Baskets = basketDtos
            };
        }
    }
}
