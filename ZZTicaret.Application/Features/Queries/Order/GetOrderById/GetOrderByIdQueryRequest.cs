using MediatR;

namespace ZZTicaret.Application.Features.Queries.Order.GetOrderById
{
    public class GetOrderByIdQueryRequest : IRequest<GetOrderByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}