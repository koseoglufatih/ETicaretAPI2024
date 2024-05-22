using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Features.Queries.Order.GetAllOrder;
using ZZTicaret.Application.Features.Queries.Order.GetOrderById;
using ZZTicaret.Application.Features.Queries.User.GetAllUser;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<GetAllUserQueryResponse> GetAllUsers();
    }
}
