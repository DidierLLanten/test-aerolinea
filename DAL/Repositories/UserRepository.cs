using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using WebApiAerolinea.Repositories.Interfaces;

namespace WebApiAerolinea.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
