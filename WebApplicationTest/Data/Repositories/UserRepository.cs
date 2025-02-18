using Microsoft.EntityFrameworkCore;
using WebApplicationTest.Data.Interfaces;
using WebApplicationTest.Models;

namespace WebApplicationTest.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly TestDbContext _databaseContext;

        public UserRepository(TestDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<int> CreateUser(User user)
        {
            _databaseContext.Users.Add(user);
            await _databaseContext.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _databaseContext.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            _databaseContext.Users.Remove(user);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<int> EditUser(User user)
        {
            var userToEdit = await _databaseContext.Users.Where(x => x.UserId == user.UserId).FirstOrDefaultAsync();
            userToEdit.Name = user.Name;
            userToEdit.Age = user.Age;
            await _databaseContext.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<List<User>> GetUsers()
        {
            var result = await _databaseContext.Users.ToListAsync();
            return result;
        }

        public async Task<string> GetImage()
        {
            var imageUrl = "https://tedsstorage1322025.blob.core.windows.net/img-pub/img_pub.png";
            using var httClient = new HttpClient();
            var imageBytes = await httClient.GetByteArrayAsync(imageUrl);
            return Convert.ToBase64String(imageBytes);
        }
    }
}
