using POS.Doamin.Entities;
using POS.Infrastructure.Commons.Bases.Response;

namespace POS.Infrastructure.Persistences.Interfaces;

public interface IUserRepository
{
    // Task<BaseIntityResponse<User>> ListUser();
    Task<IEnumerable<User>> ListUser();
    Task<User> UserById(int UserId);
    Task<bool> RegisterUser(User user);
    Task<bool> editUser(User user);
    Task<bool> RemoveUser(int UserId);
}
