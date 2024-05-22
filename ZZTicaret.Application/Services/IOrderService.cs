using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.Order;

namespace ZZTicaret.Application.Services
{
    public interface IOrderService
    {
        Task<OrderViewModel> GetOrderById(Guid orderId);
        Task<List<OrderViewModel>> GetAllOrders();
        Task CreateOrder(CreateOrder createOrder);
        Task UpdateOrder(Guid orderId, OrderViewModel model);
        Task DeleteOrder(Guid orderId);

    }
}
