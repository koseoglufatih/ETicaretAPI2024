using ZZTicaret.Application.DTO.Order;
using ZZTicaret.Application.DTO.User;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(Guid userId);
        Task<List<UserViewModel>> GetAllOrders();
        Task CreateUserAsync(CreateUser createUser);
        Task UpdateUser(User user);
        Task DeleteUser(Guid userId);
    }
}
