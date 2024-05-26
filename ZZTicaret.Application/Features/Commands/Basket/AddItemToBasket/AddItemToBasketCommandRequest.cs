using MediatR;

namespace ZZTicaret.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandRequest : IRequest<AddItemToBasketCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}