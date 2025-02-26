using BaiTap2.Models;

namespace BaiTap2.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserById(int userId);
        Task<User> CreateUser(User user);
        Task<User?> UpdateUser(int userId, User user);
        Task<bool> DeleteUser(int userId);
    }
}
