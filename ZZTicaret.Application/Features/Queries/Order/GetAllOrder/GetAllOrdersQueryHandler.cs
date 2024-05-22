using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Application.Services;

namespace ZZTicaret.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, GetAllOrdersQueryResponse>
    {
        readonly IOrderRepository _orderRepository;
        



        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IOrderService orderService)
        {
            _orderRepository = orderRepository;
            
        }

        public async Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            

            var orders = await _orderRepository.GetAllAsync();
            return new GetAllOrdersQueryResponse()
            {
                Orders = orders
            };
        }
    }
}
