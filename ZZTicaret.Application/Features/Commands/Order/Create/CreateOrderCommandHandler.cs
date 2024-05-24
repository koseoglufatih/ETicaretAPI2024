using MediatR;
using ZZTicaret.Application.Repositories;

namespace ZZTicaret.Application.Features.Commands.Order.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {

            var neworder = new Domain.Order()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                UserId = request.UserId,
                OrderDate = DateTime.Now,

            };

            
            neworder.TotalAmount = 0;
            foreach (var item in request.OrderDetails)
            {
                neworder.OrderDetails.Add(new Domain.OrderDetail()
                {

                    Id = Guid.NewGuid(),
                    ProductId = item.ProductId,
                    Price = item.Price,
                    Quantity = item.Quantity

                }); ;
                neworder.TotalAmount += item.Quantity * item.Price;
            }


            await _orderRepository.AddAsync(neworder);


            return new CreateOrderCommandResponse()
            {

                Message = "Sipariş Oluşturuldu. Sipariş Id: " + neworder.Id,
                Success = true,
                TotalAmount = neworder.TotalAmount
            };




        }
    }
}
