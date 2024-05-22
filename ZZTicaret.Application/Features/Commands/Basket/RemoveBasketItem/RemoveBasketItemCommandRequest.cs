using MediatR;

namespace ZZTicaret.Application.Features.Commands.Basket.RemoveBasketItem
{
    public class RemoveBasketItemCommandRequest : IRequest<RemoveBasketItemCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}