using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Repositories
{
    public interface IBasketItemRepository : IRepository<BasketItem>
    {
        Task AddAsync(BasketItem basketItem);
        Task<List<BasketItem>> GetBasketByUserIdAsync(Guid UserId);

    }
}
