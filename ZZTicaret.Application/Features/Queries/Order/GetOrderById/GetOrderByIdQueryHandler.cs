using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Features.Queries.Category.GetByIdCategory;
using ZZTicaret.Application.Repositories;

namespace ZZTicaret.Application.Features.Queries.Order.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
    {
        readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Order order = await _orderRepository._dbSet
                .Include(p => p.User)
                .Include(p => p.OrderDetails).ThenInclude(p=>p.Product)
                .Where(o => o.Id == request.Id).FirstOrDefaultAsync();


            decimal totalFiyat = 0;
            foreach (var item in order.OrderDetails)
            {
                totalFiyat += item.Quantity * item.Price;
            }

            var response = new GetOrderByIdQueryResponse()
            {
                OrderDetail = new DTO.Order.OrderDTO()
                {
                    OrderDate = DateTime.Now,
                    UserId = order.UserId,
                    TotalAmount = totalFiyat
                }
            };

            foreach (var item in order.OrderDetails)
            {
                response.OrderDetail.OrderDetails.Add(new DTO.Order.OrderDetailDTO2()
                { 
                    Id = item.Id,
                    Price = item.Price,
                    ProductId = item.ProductId, 
                    Quantity    = item.Quantity,
                    ProductName= item.Product.Name
                });
            }

            return response;
        }
    }
}
