using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using ZZTicaret.Application.DTO.Basket;
using ZZTicaret.Application.DTO.User;
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
            var addBasketItem = await _context.Baskets.Include(b => b.BasketItems).FirstOrDefaultAsync(bi => bi.Id== UserId);
            return new AddItemToBasketCommandResponse
            {
                Message = "Sepete başarıyla ürün eklendi.",
                Success = true

            };


        }

        public async Task<GetAllBasketsQueryResponse> GetAllBaskets()
        {
            var baskets = await _context.Baskets
                .Include(b => b.BasketItems)
                .Include(b => b.User)
                .Select(b => new BasketDto
                {
                    UserId = b.UserId,
                    BasketItems = b.BasketItems.Select(i => new BasketItemDTO
                    {
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                        Price = i.Price
                    }).ToList(),
                    User = new UserDto
                    {
                        NameSurname = b.User.NameSurname,
                        Email = b.User.Email
                    }
                }).ToListAsync();

            return new GetAllBasketsQueryResponse { Baskets = baskets };
        }

        public async Task<Basket> GetByIdAsync(Guid userId)
        {



            return await _context.Baskets
                .Include(b => b.User)
                .FirstOrDefaultAsync(u => u.Id == userId);

        }
    }
}
               





