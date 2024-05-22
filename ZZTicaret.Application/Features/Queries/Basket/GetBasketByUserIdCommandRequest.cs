using MediatR;

namespace ZZTicaret.Application.Features.Queries.Basket
{
    public class GetBasketByUserIdCommandRequest : IRequest<GetBasketByUserIdCommandResponse>
    {
        public Guid UserId { get; set; }
    }
}