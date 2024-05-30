using biblioteca_fc_api.Data;
using biblioteca_fc_api.Models;
using biblioteca_fc_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_fc_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BibiotecaDbContext _dbContext;
        public UserRepository(BibiotecaDbContext bibiotecaDbContext)
        {
            _dbContext = bibiotecaDbContext;
        }

        public async Task<List<UserModel>> CreateUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<List<UserModel>> FindAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> FindUserById(int id)
        {
            return await _dbContext.Users.FindAsync(id);    
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userData = await FindUserById(id);

            if (userData == null)
            {
                throw new Exception("User not foud!");
            }

            userData.Name = user.Name;
            userData.Email = user.Email;

            _dbContext.Users.Update(userData);
            await _dbContext.SaveChangesAsync();

            return userData;
        }

        public async Task<bool> RemoveUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not foud!");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}