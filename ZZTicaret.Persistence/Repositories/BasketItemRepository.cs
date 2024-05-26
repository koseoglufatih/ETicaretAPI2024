using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Persistence.Repositories
{
    public class BasketItemRepository : Repository<BasketItem>, IBasketItemRepository
    {
        private readonly ZZTicaretContext _context;

        public BasketItemRepository(ZZTicaretContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<BasketItem>> GetBasketByUserIdAsync(Guid UserId)
        {
            return await _context.BasketItems
                .Include(bi => bi.Basket)
                .Where(bi => bi.Basket.UserId == UserId)
                .ToListAsync();
        }

        public async Task AddAsync(BasketItem basketItem)
        {
            await _context.BasketItems.AddAsync(basketItem);
            await _context.SaveChangesAsync();

        }
    }
}
