using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Application.Services;

namespace ZZTicaret.Application.Features.Queries.Basket.GetBasketItems
{
    public class GetBasketTotalQueryHandler : IRequestHandler<GetBasketTotalQueryRequest, GetBasketTotalQueryResponse>
    {
        readonly IBasketService _basketService;
       


        public GetBasketTotalQueryHandler(IBasketService basketService, IBasketRepository basketRepository)
        {
            _basketService = basketService;
            
        }

        public async Task<GetBasketTotalQueryResponse> Handle(GetBasketTotalQueryRequest request, CancellationToken cancellationToken)
        {

            var totalAmount = await _basketService.GetBasketTotal(request.UserId);
            return new GetBasketTotalQueryResponse { TotalAmount = totalAmount };

        }
    }
}
