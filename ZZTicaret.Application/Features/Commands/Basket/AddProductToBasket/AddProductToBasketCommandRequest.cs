using MediatR;

namespace ZZTicaret.Application.Features.Commands.Basket.AddProductToBasket
{
    public class AddProductToBasketCommandRequest : IRequest<AddProductToBasketCommandResponse>            
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
