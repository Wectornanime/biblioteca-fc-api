using biblioteca_fc_api.Models;

namespace biblioteca_fc_api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> FindAllUsers();
        Task<UserModel> FindUserById(int id);
        Task<List<UserModel>> CreateUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<bool> RemoveUser(int id);
    }
}