using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            await _context.Baskets
            .Include(b => b.BasketItems)
            .FirstOrDefaultAsync(b => b.UserId == UserId);

            return new AddItemToBasketCommandResponse
            {
                Message = "Sepete başarıyla ürün eklendi",

                Success = true


            };

        }




    }
}

