using WebApplicationTest.Models;

namespace WebApplicationTest.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<int> EditUser(User user);
        Task<int> CreateUser(User user);
        Task<bool> DeleteUser(int userId);
        Task<string> GetImage();
    }
}
