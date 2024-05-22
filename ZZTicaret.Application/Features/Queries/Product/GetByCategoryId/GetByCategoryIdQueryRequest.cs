using MediatR;

namespace ZZTicaret.Application.Features.Queries.Product.GetByCategoryId
{
    public class GetByCategoryIdQueryRequest : IRequest<GetByCategoryIdQueryResponse>
    {
        public Guid CategoryId { get; set; }
        public bool All { get; set; }
    }
}