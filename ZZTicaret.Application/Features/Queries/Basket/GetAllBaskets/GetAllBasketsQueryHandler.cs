using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Repositories;

namespace ZZTicaret.Application.Features.Queries.Basket.GetAllBaskets
{
    public class GetAllBasketsQueryHandler : IRequestHandler<GetAllBasketsQueryRequest, GetAllBasketsQueryResponse>
    {
        readonly IBasketRepository _basketRepository;

        public GetAllBasketsQueryHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<GetAllBasketsQueryResponse> Handle(GetAllBasketsQueryRequest request, CancellationToken cancellationToken)
        {
            var baskets = await _basketRepository.GetAllAsync();
            return new GetAllBasketsQueryResponse()
            {
                Baskets = baskets
            };
        }
    }
}
