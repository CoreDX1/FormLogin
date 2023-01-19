namespace POS.Infrastructure.Persistences.Interfaces;

public interface IUnitOfWork : IDisposable
{
    // Declaracion o matriculas de nuestra interface a nivel de repositorio
    // Todas las declaraciones de las interface a nivel de repositorio
    IUserRepository User { get; }
    void SaveChanges();
    Task SaveChangesAsync();
}
