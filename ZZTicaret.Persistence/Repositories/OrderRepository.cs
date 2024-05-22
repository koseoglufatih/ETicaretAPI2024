using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Features.Queries.Order.GetAllOrder;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ZZTicaretContext _context;
        public OrderRepository(ZZTicaretContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GetAllOrdersQueryResponse> GetAllOrders()
        {
            var orders = await _context.Orders
                .Include(x => x.User)
                .Include(u=> u.OrderDetails)
            .ToListAsync();
                
                

            return new GetAllOrdersQueryResponse
            {
                Orders = orders
            };

        }
    }
}
