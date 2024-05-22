using Microsoft.EntityFrameworkCore;
using ZZTicaret.Application.DTO.Order;
using ZZTicaret.Application.DTO.User;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;

        }
        public async Task CreateUserAsync(CreateUser createUser)
        {
            var user = new User
            {
                Email = createUser.Email,
                NameSurname = createUser.Name,
                CreateDate = DateTime.Now,
                Password = createUser.Password,
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteUser(Guid userId)
        {
            var deleteuser = await _userRepository.GetByIdAsync(userId);
            if (deleteuser == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            var result = await _userRepository.Delete(userId);
            if (!result)
            {
                throw new Exception("Kullanıcı silinemedi");
            }

        }

        public async Task<List<UserViewModel>> GetAllOrders()
        {
            var orders = await _userRepository.GetAllAsync();
            return new List<UserViewModel>();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task UpdateUser(User user)
        {
            _userRepository._dbSet.Entry(user).State = EntityState.Modified;
            await _userRepository.SaveAsync();
        }
    }
}
