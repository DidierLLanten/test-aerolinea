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

        public async Task<IEnumerable<User>> GetByEmailFragmentAsync(string emailFragment)
        {            
            return await _context.Set<User>()
               .Where(u => u.Email.Contains(emailFragment))
               .ToListAsync();
        }
    }
}
