using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using ZZTicaret.Application.Features.Commands.Basket.AddItemToBasket;
using ZZTicaret.Application.Features.Queries.Basket.GetAllBaskets;
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
            var addBasketItem = await _context.Baskets.Include(b => b.User).ThenInclude(u => u.Orders).FirstOrDefaultAsync(o=> o.UserId == UserId);
            return new AddItemToBasketCommandResponse
            {
                Message = "Sepete başarıyla ürün eklendi.",
                Success = true
                
            };


        }

        public async Task<GetAllBasketsQueryResponse> GetAllBaskets()
        {
            var baskets = await _context.Baskets
                 .Include(b => b.BasketItems).ToListAsync();

            return new GetAllBasketsQueryResponse
            {
                Baskets = baskets
            };

                
        }
    }
}

