
using POS.Infrastructure.Persistences.Context;
using POS.Infrastructure.Persistences.Interfaces;

namespace POS.Infrastructure.Persistences.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly FormContext _context;

    // Declacion de la interfaz
    public IUserRepository User {get; private set; }

    public UnitOfWork(FormContext context)
    {
        this._context = context;
        User = new UserRepository(_context);
    }

    // Liberar los recursos del sistema

    public void Dispose()
    {
        _context.Dispose();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
