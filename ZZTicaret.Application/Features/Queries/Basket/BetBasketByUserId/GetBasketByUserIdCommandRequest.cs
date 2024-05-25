using MediatR;
using ZZTicaret.Application.DTO.Basket;

namespace ZZTicaret.Application.Features.Queries.Basket.BetBasketByUserId
{
    public class GetBasketByUserIdCommandRequest : IRequest<GetBasketByUserIdCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid BasketId { get; set; }
        public List<BasketItemDTO> BasketItems { get; set; } = new List<BasketItemDTO>();
    }
}