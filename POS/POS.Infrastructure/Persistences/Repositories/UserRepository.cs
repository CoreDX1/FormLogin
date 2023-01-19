using POS.Doamin.Entities;
using POS.Infrastructure.Persistences.Context;
using POS.Infrastructure.Persistences.Interfaces;

namespace POS.Infrastructure.Persistences.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FormContext _context;

    public UserRepository(FormContext context)
    {
        this._context = context;
    }

    public Task<IEnumerable<User>> ListUser()
    {
        throw new NotImplementedException();
    }

    public Task<bool> editUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RegisterUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveUser(int UserId)
    {
        throw new NotImplementedException();
    }

    public Task<User> UserById(int UserId)
    {
        throw new NotImplementedException();
    }
}
