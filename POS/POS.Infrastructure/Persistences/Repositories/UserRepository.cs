
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
    }