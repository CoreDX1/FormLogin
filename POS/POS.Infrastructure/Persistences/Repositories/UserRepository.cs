using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<User>> ListSelectUser()
    {
        var user = await _context.User.Where(x => x.Status.Equals(1)).AsNoTracking().ToListAsync();
        return user;
    }

    public async Task<User> UserById(int UserId)
    {
        var user = await _context.User!
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.UserId.Equals(UserId));
        return user!;
    }

    public async Task<bool> RegisterUser(User user)
    {
        await _context.AddAsync(user);
        var recordAffected = await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EditUser(User user)
    {
        _context.Update(user);
        _context.Entry(user).Property(x => x.DateRegister).IsModified = false;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveUser(int UserId)
    {
        var user = await _context.User
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.UserId.Equals(UserId));
        _context.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
