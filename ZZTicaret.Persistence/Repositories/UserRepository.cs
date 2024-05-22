using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Features.Queries.Category.GetAllCategory;
using ZZTicaret.Application.Features.Queries.Order.GetOrderById;
using ZZTicaret.Application.Features.Queries.Product.GetByCategoryId;
using ZZTicaret.Application.Features.Queries.User.GetAllUser;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Persistence.Repositories
{

    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ZZTicaretContext _context;
        public UserRepository(ZZTicaretContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GetAllUserQueryResponse> GetAllUsers()
        {
            var users =  await _context.Users.Include(x=> x.Orders).ToListAsync();
            return new GetAllUserQueryResponse
            {
                Users = users
            };

            
        }
    }
}
