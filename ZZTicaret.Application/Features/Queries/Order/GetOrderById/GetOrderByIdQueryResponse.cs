using ZZTicaret.Application.DTO.Order;
using ZZTicaret.Application.Features.Commands.Order.Create;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Features.Queries.Order.GetOrderById
{
    public class GetOrderByIdQueryResponse
    {

        public OrderDTO OrderDetail { get; set; }
       
        
    }
}