using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Features.Commands.Basket.AddItemToBasket;
using ZZTicaret.Application.Features.Queries.Order.GetAllOrder;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Persistence.Repositories
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {

        private readonly ZZTicaretContext _context;
        public BasketRepository(ZZTicaretContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AddItemToBasketCommandResponse> AddItemToBasket(Guid UserId)
        {
            var basket = await _context.Baskets
                .Include(b => b.User)
                .ThenInclude(o=> o.Orders)
                .FirstOrDefaultAsync(o=>o.UserId == UserId);

            return new AddItemToBasketCommandResponse
            {
                Message = "Sepet başarılı",
                Success = true,
            };

           


        }
    }
}
