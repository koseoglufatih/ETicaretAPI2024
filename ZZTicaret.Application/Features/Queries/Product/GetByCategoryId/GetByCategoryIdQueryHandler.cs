using MediatR;
using ZZTicaret.Application.Repositories;

namespace ZZTicaret.Application.Features.Queries.Product.GetByCategoryId
{
    public class GetByCategoryIdQueryHandler : IRequestHandler<GetByCategoryIdQueryRequest, GetByCategoryIdQueryResponse>
    {
        readonly IProductRepository _productRepository;

        public GetByCategoryIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetByCategoryIdQueryResponse> Handle(GetByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductListByCategoryId(request.CategoryId);
            
        }
    }
}
