using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Features.Queries.Order.GetAllOrder;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<GetAllOrdersQueryResponse>GetAllOrders();
    }
}
