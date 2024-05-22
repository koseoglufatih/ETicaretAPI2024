using MediatR;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Features.Commands.Order.Create
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public Guid UserId { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }

    }
    public class OrderDetailDTO
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}