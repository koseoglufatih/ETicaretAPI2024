using MediatR;

namespace ZZTicaret.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrdersQueryRequest : IRequest<GetAllOrdersQueryResponse>
    {
        public decimal TotalAmount { get; set; }
    }
}