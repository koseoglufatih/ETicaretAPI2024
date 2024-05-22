using ZZTicaret.Application.DTO.User;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(Guid userId);
        Task<List<User>> GetAllUsers();
        Task CreateUserAsync(CreateUser createUser);
        Task UpdateUser(User user);
        Task DeleteUser(Guid userId);
    }
}
